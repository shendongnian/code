    public class ThingModelBinder : DefaultModelBinder
    {
        IThingFactory ThingFactory;
    
        public ThingModelBinder(IThingFactory thingFactory)
        {
            this.IThingFactory = thingFactory;
        }
    
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            Thing thing = new Thing();
    
            string id_string = controllerContext.RouteData.Values["id"].ToString();
            int id = 0;
            Int32.TryParse(id_string, out id);
            var thing = thingFactory.Get(id);
    
            return thing;
        }
    
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
    
            // custom section
            object model = this.CreateModel(controllerContext, bindingContext, typeof(Thing));
    
            // set back to ModelBindingContext
            bindingContext.ModelMetadata.Model = model;
    
            // call base class version
            // this will use the overridden version of CreateModel() which calls the Repository
            // object model = BindComplexModel(controllerContext, bindingContext);
    
            return base.BindModel(controllerContext, bindingContext);
    
        }
