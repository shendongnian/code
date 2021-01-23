    /// <summary>
    /// Scope callbacks for standard scopes.
    /// </summary>
    public class StandardScopeCallbacks
    {
        /// <summary>
        /// Gets the callback for transient scope.
        /// </summary>
        public static readonly Func<IContext, object> Transient = ctx => null;
        #if !NO_WEB
        /// <summary>
        /// Gets the callback for request scope.
        /// </summary>
        public static readonly Func<IContext, object> Request = ctx => HttpContext.Current;
        #endif
    }
