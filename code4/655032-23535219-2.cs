    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AutofacResolveAttribute : LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            args.ProceedGetValue();
            if (!args.Location.LocationType.IsInterface) return;
 
            if ( args.Value != null )
            {
               args.Value = DependencyResolver.Current.GetService(args.Location.LocationType);
               args.ProceedSetValue();
            }
        }
    }
