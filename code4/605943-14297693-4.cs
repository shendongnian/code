    public void PlayBackCachedEvents()
    {
        BulkChangesStart();   // Raise Event to notify GUI to suspend screen updates
    
        // Play back the list of events to push changes 
        foreach (var batch in _replayer.ToEnumerable())
        {
            foreach(var evt in batch)
            {
                switch(evt.Item2)
                {
                    case ThingEventType.Add: this.AddingThing(evt.Item1);break;
                    case ThingEventType.Change: this.ChangingThing(evt.Item1);break;
                    case ThingEventType.Remove: this.RemovingThing(evt.Item1);break;
                }
            }
        }
        BulkChangesEnd();   // Raise Event to notify GUI to allow control refresh
    }
