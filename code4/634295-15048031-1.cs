    public class MyBusinessClass
        : IMyBusinessClass
    {
        public MyBusinessClass(
            IFilterProvider filterProvider
            )
        {
            if (filterProvider == null)
                throw new ArgumentNullException("filterProvider");
            this.filterProvider = filterProvider;
        }
        protected readonly IFilterProvider filterProvider;
		
		public IEnumerable<AuthorizeAttribute> GetAuthorizeAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
		{
			var filters = filterProvider.GetFilters(controllerContext, actionDescriptor);
			
			return filters
                    .Where(f => typeof(AuthorizeAttribute).IsAssignableFrom(f.Instance.GetType()))
                    .Select(f => f.Instance as AuthorizeAttribute);
		}
	}
