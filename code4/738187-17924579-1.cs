    protected override IEnumerable<Device> enumerate()
    {
        ... reflect to get properties of type IEnumerable<Device>
        foreach (var prop in properties) 
        {
            foreach (var device in (IEnumerable<Device>)prop.GetValue(this))
            {
                yield return device;
            }
        }
    }
