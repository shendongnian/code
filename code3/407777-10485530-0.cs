    /// <summary>
    /// Custom Implementation of the Validate Anti Forgery Token Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// The ValidateAntiForgeryTokenAttribute.
        /// </summary>
        private readonly ValidateAntiForgeryTokenAttribute _validator;
        /// <summary>
        /// The AcceptVerbsAttribute.
        /// </summary>
        private readonly AcceptVerbsAttribute _verbs;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomValidateAntiForgeryTokenAttribute"/> class.
        /// </summary>
        /// <param name="verbs">The verbs.</param>
        public CustomValidateAntiForgeryTokenAttribute(HttpVerbs verbs) : this(verbs, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomValidateAntiForgeryTokenAttribute"/> class.
        /// </summary>
        /// <param name="verbs">The verbs.</param>
        /// <param name="salt">The salt.</param>
        public CustomValidateAntiForgeryTokenAttribute(HttpVerbs verbs, string salt)
        {
            _verbs = new AcceptVerbsAttribute(verbs);
            _validator = new ValidateAntiForgeryTokenAttribute
                             {
                                 Salt = salt
                             };
        }
        /// <summary>
        /// Called when authorization is required.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpMethodOverride = filterContext.HttpContext.Request.GetHttpMethodOverride();
            
            var found = false;
            foreach (var verb in _verbs.Verbs)
            {
                if (verb.Equals(httpMethodOverride, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                }
            }
            if (found && !filterContext.RequestContext.RouteData.Values["action"].ToString().StartsWith("Json"))
            {
                _validator.OnAuthorization(filterContext);
            }
        }
    }
