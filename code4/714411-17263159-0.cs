    private void Refresh()
    {
        _published.DisposeIfNotNull();
        if (_stream != null)
        {
            var connectable = _stream.Publish();
            _published = connectable.Connect();
            var stream = connectable.AsObservable();
            foreach (var eventReceiver in _eventReceivers)
            {
                eventReceiver.Apply(stream);
                stream = stream.Where(eventReceiver.ShouldForwardEvent);
            }
        }
    }
