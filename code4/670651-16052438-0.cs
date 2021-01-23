    public class ObjectHaverPlus : IHaveObjects, IHaveObjectsEnhanced
    {
        public object FirstObject()
        {
        }
        public object FirstObjectOrFallback()
        {
             return FirstObject() ?? GetDefault();
        }
    }
