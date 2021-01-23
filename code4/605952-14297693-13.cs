    public void PlayBackCachedEvents()
    {
        BulkChangesStart();   // Raise Event to notify GUI to suspend screen updates
    
        // Play back the list of events to push changes 
        lock(SyncRoot)
        {
            foreach(var batch in _eventQueue)
            {
                // Play back the list of events to push changes to ListView, TreeView, graphs, etc...            
                foreach(var evt in batch)
                {
                    switch(evt.Item2)
                    {
                        case ThingEventType.Add: BufferedAdds.OnNext(evt.Item1); break;
                        case ThingEventType.Change: BufferedChanges.OnNext(evt.Item1);break;
                        case ThingEventType.Remove: BufferedRemoves.OnNext(evt.Item1);break;
                    }
                }
            }
            _eventQueue.Clear();
        }
        BulkChangesEnd();   // Raise Event to notify GUI to allow control refresh
    }
