    public class HomeController: {
         // model
         public class PDocument {
              public string pcontent {get;set;}
         }
    
         [HttpPost]
         public ActionResult SaveDocument(PDocument pcontent){
              // do something
              return new JsonResult() { Data = new { Success = true } };
         }
    }
