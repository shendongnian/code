    static void Main(string[] args)
    {
        using(ResXResourceWriter writer = new ResXResourceWriter("output.resx"))
        {
            foreach (object value in Enum.GetValues(typeof(Keys)))
            {
                string name = Enum.GetName(typeof(Keys), value);
                string description = GetDescription((Keys)value);
                
                if(description != null)
                    writer.AddResource(new ResXDataNode(name, description));
            }
        }
    }
