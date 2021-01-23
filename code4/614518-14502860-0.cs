    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyInitializerAttribute : Attribute
    {
        AssemblyInitializerAttribute ()
        {
        }
        AssemblyInitializerAttribute (string typeName)
        {
            TypeName = typeName;
        }
        public string TypeName;
    }
