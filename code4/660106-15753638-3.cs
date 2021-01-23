    public IEnumerable<MyRoot> MapMyRootDTO(MyRootDTO root)
    {
        return root.Devices.Select(r => new MyRoot
        {
            Key = r.Key,
            Name = r.Value.Name
            Type = r.Value.Type
        });
    }
