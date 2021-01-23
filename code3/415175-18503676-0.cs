    public sealed class TEST: ActionFilterAttribute
    {
       /// <summary>
        /// Model variable getting passed into action method
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// Empty Contructor
        /// </summary>
        public TEST()
        {
        }
        /// <summary>
        /// This is to get the model value by variable name passsed in Action method
        /// </summary>
        /// <param name="modelName">Model variable getting passed into action method</param>
        public TEST(string modelName)
        {
            this.ModelName = modelName;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = filterContext.ActionParameters.SingleOrDefault(ap => ap.Key.ToLower() == ModelName.ToString()).Value;
        }
    }
        THIS IS OUR ACTION METHOD PLEASE NOTE model variable has to be same
        [HttpPost]
        [TEST(ModelName = "model")]
        public ActionResult TESTACTION(TESTMODEL model)
        {
        }
