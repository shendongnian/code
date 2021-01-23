    public static void ForceListUpdate()
    {
        if (_dataSource.Content.Count != 0)
            _dataSource.Content.Move(0, 0);
    }
