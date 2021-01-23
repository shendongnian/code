    using (Sync sync = this.syncFactory.Create(CSettings, ItemRemoved))
    {
        //some code
    }
    using (Sync sync = this.syncFactory.Create(CSettings))
    {
        //some code
    }
    using (Sync sync = this.syncFactory.Create(stringValue)
    {
        sync.Remove();
    }
