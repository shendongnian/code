    public class DocumentModel
    {
        public DocumentModel()
        {
            _translations = new List<DocumentTranslation>();
        }
        public int Id { get; set; }
        public int OwnerId { get; set; }
        private List<DocumentTranslation> _translations;
        public IEnumerable<DocumentTranslation> Translations
        {
            get { return _translations; }
            set { _translations = value.ToList(); }
        }
    }
