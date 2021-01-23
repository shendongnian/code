    public class FastJsonResult : ActionResult // or maybe derive from JsonResult
    {
        private object model;
        public FastJsonResult(object model) 
        {
            this.model = model;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            // code to set content type and write serialized response
        }
    }
