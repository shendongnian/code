    public class Something {
    
       public ActionResult Index(int id) {
           var model = new SomeRelatedStuff.Load(id);
           return View(model);
       }
    }
    private class SomeRelatedStuff {
       public SomeRelatedStuff()
       public static SomeRelatedStuff Load(int id) {
           var something = GetSomething();
           var somethingElse = GetSomethingElse(something);
           var model = new SomeViewModel(somethingElse);
           MakeObject();
           return this;
       }
       private string GetSomething() {
           ...
           return someVal;
       }
       private SomeObject GetSomethingElse(string something) {
           ...
           return someBigObject;
       }
       private void MakeObject () {
           ...
       }
    
    }
