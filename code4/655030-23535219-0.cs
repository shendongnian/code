    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AutofacResolveAttribute : LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            if(args.Value != null) args.ProceedGetValue();
            if (!args.Location.LocationType.IsInterface) return;
            args.Value = DependencyResolver.Current.GetService(args.Location.LocationType);
        }
    }
