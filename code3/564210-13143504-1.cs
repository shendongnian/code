    public IList<ExtendedEvent> GetExtendedEvents() {
        using (var context = new MyDatabaseContext()) {
            return context.Events
                .Select(evnt => new {
                    TheEvent = evnt,
                    SomeExtraData = 123,
                    ActualAssessment = evnt.ActualAssessment
                })
                .ToList()
                .Select(evntInfo => {
                    return new ExtendedEvent {
                        TheEvent = evntInfo.TheEvent,
                        SomeExtraData = evntInfo.SomeExtraData
                    };
                })
                .ToList();
        }
    }
