    public bool IsLightFile(string filename)
    {
        return Enum.GetNames(typeof(LightFiles)).Contains(
            Path.GetExtension(filename).Remove(0, 1).ToUpper());
    }
                
