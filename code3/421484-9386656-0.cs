    /// <summary>
    ///     Attribute that signals that a dependency should be injected.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class InjectDependencyAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref = "InjectDependencyAttribute" /> class.
        /// </summary>
        public InjectDependencyAttribute()
        {
            this.PreserveExistingValue = false;
        }
        /// <summary>
        /// Gets or sets a value indicating whether to preserve an existing non-null value.
        /// </summary>
        /// <value>
        /// <c>true</c> if the injector should preserve an existing value; otherwise, <c>false</c>.
        /// </value>
        public bool PreserveExistingValue { get; set; }
    }
