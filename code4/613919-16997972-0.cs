    private void TryAddEvent(IStoreEvents storeEvents, IUserEvent anEvent, Guid streamId)
    {
        var isCommitSuccessful = false;
        for (var i = 0; i < 10 && !isCommitSuccessful; i++)
        {
            try
            {
                using (var stream = storeEvents.OpenStream(streamId, 0, int.MaxValue))
                {
                    stream.Add(new EventMessage {Body = anEvent});
                    if (stream.UncommittedEvents.All(e => e.Body != anEvent))
                    {
                        stream.Add(new EventMessage {Body = anEvent});
                    }
                    stream.CommitChanges(Guid.NewGuid());
                }
                isCommitSuccessful = true;
            }
            catch (Exception ex)
            {
                if (!(ex is SqlException) && !(ex is ConcurrencyException))
                {
                    throw;
                }
                using (var stream = storeEvents.OpenStream(streamId, 0, int.MaxValue))
                {
                    if (stream.CommittedEvents.Any(e => e.Body == anEvent))
                    {
                        isCommitSuccessful = true;
                    }
                }
            }
        }
        if (!isCommitSuccessful)
        {
            throw new ConcurrencyException(String.Format("Cannot add {0} to event store", anEvent.GetType()));
        }
    }
