    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ResourceDictionaryExportAttribute : ExportAttribute
    {
        public ResourceDictionaryExportAttribute() : base("Resourcen", typeof(ResourceDictionary))
        {
        }
    }
