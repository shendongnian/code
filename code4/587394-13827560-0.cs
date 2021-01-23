    namespace YourModelsNamespace
    {
        [MetadataType(typeof(ISomethingMD))]
        public partial class ISomething
        {
        }
    
        public partial class ISomethingMD
        {
            [AllowHtml]
            public string Descriptin { get; set; }
        }
    }
