    public class SomeController: MyBaseController
    {
        public ActionResult SomeAction()
        { 
            var model = new ChartModel()
                       { 
                           Labels = ..., 
                           Tooltips = ... 
                       };
            return JsonContract(model);
        }
    }
