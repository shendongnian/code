    public class MySerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            switch(typeName)
            {
                case "WebSolution.MyModel[]": return typeof(Application.MyModel[]);
                case "WebSolution.MyModel": return typeof(Application.MyModel);
                default: return base.BindToType(assemblyName, typeName);
            }
            
        }
    }
