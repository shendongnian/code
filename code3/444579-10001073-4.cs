    static void Main(string[] args)
    {
        using(ResXResourceWriter writer = new ResXResourceWriter("output.resx"))
        {
            //since there are duplicate values, we need to clumsily look at each name, then parse
            foreach (string name in Enum.GetNames(typeof(Keys)))
            {
                object value = Enum.Parse(typeof(Keys), name);
                string description = GetDescription((Keys)value); 
                
                if (description != null)
                    writer.AddResource(new ResXDataNode(name, description));
            }
        }
    }
