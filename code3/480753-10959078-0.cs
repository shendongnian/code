    public sealed class DynamicTempDataDictionary : DynamicObject
    {
        private readonly Func<TempDataDictionary> _tempDataThunk;
        public DynamicTempDataDictionary(Func<TempDataDictionary> viewDataThunk)
        {
            _tempDataThunk = viewDataThunk;
        }
        private TempDataDictionary ViewData
        {
            get { return _tempDataThunk(); }
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return ViewData.Keys;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = ViewData[binder.Name];
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            ViewData[binder.Name] = value;
            return true;
        }
    }
    public static class TempBagExtensions
    {
        private const string TempBagKey = "__CurrentTempBagDictionary";
    
        public static dynamic TempBag(this ControllerBase controller)
        {
            return GetCurrentDictionary(controller.ControllerContext);
        }
    
        public static dynamic TempBag(this WebViewPage viewPage)
        {
            return GetCurrentDictionary(viewPage.ViewContext.Controller.ControllerContext);
        }
    
    
        private static DynamicTempDataDictionary GetCurrentDictionary(ControllerContext context)
        {
            var dictionary = context.HttpContext.Items[TempBagKey] as DynamicTempDataDictionary;
    
            if (dictionary == null)
            {
                dictionary = new DynamicTempDataDictionary(() => context.Controller.TempData);
                context.HttpContext.Items[TempBagKey] = dictionary;
            }
    
            return dictionary;
        }
    }
