    public class TargetController: Controller
    [HttpPost]
    public string TargetAction(ViewModel model)
    {
     //use model (note that the serialized form was bound to the model)
     return "http://www.stackoverflow.com";
    }
