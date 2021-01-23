    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExportMyInterfaceAttribute : Attribute, IMyInterfaceInfo
    {
        public ExportMyInterfaceAttribute(Type someProperty1, double someProperty2, string someProperty3)
            
        {
            SomeProperty1 = someProperty1;
            SomeProperty2 = someProperty2;
            SomeProperty3 = someProperty3;
        }
        public Type SomeProperty1 { get; set; }
        public double SomeProperty2 { get; set; }
        public string SomeProperty3 { get; set; }
    }
