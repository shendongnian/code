    foreach (MemoryTable table in tables)
    {
        if (!_subscribedTables.Contains(table)) {
            _subscribedTables.Add(table);
            table.RegisterEventListener(new DataChangedCallBack(this.DataReceivedEventHandler));
        }
    }
