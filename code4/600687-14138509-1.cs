    public class SomeController 
    {
      private IDocuments documentService { get; set; }      
      public SomeController( IDocuments documentService ) 
      {
        this.documentService = documentService;
      } 
      public ActionResult Get (int id)
      {
          var repository = documentService; 
  
          // do some stuff with the repository here
      }
    }
