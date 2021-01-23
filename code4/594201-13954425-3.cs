    public class SomeController: MyBaseController
    {
        public ActionResult SomeAction()
        { 
            var model = new chart(){ ... }
            return JsonContract(model);
        }
    }
