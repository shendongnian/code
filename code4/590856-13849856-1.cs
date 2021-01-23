    public static class JsonControllerExtensions
    {
         public static ActionResult FastJson(this Controller controller, object model)
         {
             return new FastJsonResult(model);
         }
    }
