    class SomeClass
    {
        private string _documentType;
        public string DocumentType
        {
            get
            {
                return _documentType;
            }
            set
            {
                _documentType = value;
            }
        }
        public SomeClass(string documentType)
        {
            DocumentType = documentType;
        }
    }
