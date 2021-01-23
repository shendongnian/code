    protected override IEnumerable<Device> enumerate()
    {
        ... reflect to get properties
        foreach (var prop in properties) 
        {
            foreach (var device in (IEnumerable<Device>)prop.GetValue(this))
            {
                yield return device;
            }
        }
    }
