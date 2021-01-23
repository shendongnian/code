    public class DocumentReferenceViewModel
    {
        public int IdDocumentReference { get; set; }
        public string DocumentTitle { get; set; }
        public string PageNbr { get; set; }
        public string Comment { get; set; }
        public DocumentReferenceViewModel(){}
        public DocumentReferenceViewModel(Document doc, DocumentReference docRef){
        
          this.DocumentTitle = doc.DocumentTitle;
          this.IdDocumentReference = docRef.IdDocumentReference;
          this.PageNbr = docRef.PageNbr ;
        }
    }
