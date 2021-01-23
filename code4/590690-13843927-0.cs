        [MetadataAttribute]
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public abstract class ModuleMetadataExportAttribute : ExportAttribute
        {
            public ModuleDescriptor Descriptor { get; private set; }
    
            public ModuleMetadata(string name, string code, string category, string iconUri)
                : base(typeof(IArmTaskModule))
            {
                Descriptor= new ModuleDescriptor(name, code, category, iconUri);               
            }
         }
