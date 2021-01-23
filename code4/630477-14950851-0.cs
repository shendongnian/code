    public void ProcessFile(string path)
    {
        Type recordType = _migration.InputRecordType;
        var getDataMethod =
            _provider.GetType()
            .GetMethod("GetData")
            .MakeGenericMethod(recordType);
        var records = getDataMethod.Invoke(_provider, new object[] { path });
        _migration.Migrate(records);
    }
