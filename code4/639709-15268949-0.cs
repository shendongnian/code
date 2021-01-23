    public class OnlyBreadCrumbMvcSiteMapNodeAttribute : MvcSiteMapNodeAttribute
    {
        public OnlyBreadCrumbMvcSiteMapNodeAttribute(string title, string parentKey)
        {
            Title = title;
            ParentKey = parentKey;
            VisibilityProvider = typeof(BreadCrumbOnlyVisibilityProvider).AssemblyQualifiedName;
        }
        public OnlyBreadCrumbMvcSiteMapNodeAttribute(string title, string parentKey, string key)
        {
            Title = title;
            Key = key;
            ParentKey = parentKey;
            VisibilityProvider = typeof(BreadCrumbOnlyVisibilityProvider).AssemblyQualifiedName;
        }
    }
