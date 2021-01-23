    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class BusinessLogicImportAttribute : ConstraintImportAttribute
    {
        public BusinessLogicImportAttribute()
            : base(typeof(IBusinessController))
        {
            base.RequiredCreationPolicy = RequiredCreationPolicy = CreationPolicy.NonShared;
        }
    }
