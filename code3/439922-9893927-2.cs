    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false), MetadataAttribute]
    public class ExportTransformAttribute : ExportAttribute, ITransformMetadata
    {  
        public ExportTransformAttribute(string name)
            : base(typeof(ITransform))
        {
            Name = name;
        }
        public string Name { get; set; }
    }
