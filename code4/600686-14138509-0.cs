    public class SomeController 
    {
      public ActionResult Get (int id)
      {
          var repository = Binder.GetImplementation<IDocuments>();
  
          // do some stuff with the repository here
      }
    }
