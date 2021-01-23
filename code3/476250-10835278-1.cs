    public class Something {
    
       public ActionResult Index() {
           MakeCallToFunction();
           var something = GetSomething();
           var somethingElse = GetSomethingElse(something);
           var model = new SomeViewModel(somethingElse);
           return View(model);
       }
    
       private void MakeCallToFunction () {
           ...
       }
    
       private string GetSomething() {
           ...
           return someVal;
       }
       private SomeObject GetSomethingElse(string something) {
           ...
           return someBigObject;
       }
    }
