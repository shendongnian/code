    public class MyModule : Autofac.Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
        {
            registration.Activated += (sender, args) =>
            {
                var my = args.Instance as MyClass;
                if (my == null) return;
    
                var type = args.Component.Activator.LimitType;
                my.Test(type);
                ...
            };
        }
    }
