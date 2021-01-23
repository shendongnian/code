    public static class ControllerExtensions
    {
         public static JsonResult DataContractJson(this Controller ctrl, object data) {
             return new DataContractJsonResult { Data = data };
         }
    }
