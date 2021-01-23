    class DocumentService
    {
        private DocumentRespository documentRespository = null;
        public DocumentRepository DocumentRepository 
        { 
            get
            {
                if (documentRepository == null) 
                    documentRepository = new DocumentRepository();
                return documentRepository;
            }
        }
        public DocumentService()
        {
        }
    }
