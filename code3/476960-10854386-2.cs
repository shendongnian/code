    foreach (MemoryTable table in tables)
    {
        _subscribedTables.Add(table);
        table.RegisterEventListener(new DataChangedCallBack(this.DataReceivedEventHandler));
    }
