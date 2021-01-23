    public class Module : NinjectModule
    {
        // stores string myArg to protect from CG
        ConcurrentBag<string> ParamSet = new ConcurrentBag<string>();
    
        public override void Load()
        {
            Bind<MyClass>()
                .ToSelf()
                // custom scope
                .InScope((context) =>
                    {
                        // get first constructor argument
                        var param = context.Parameters.First().GetValue(context, context.Request.Target) as string;                    
                        
                        // retrieves system reference to string
                        param = string.Intern(param);
                        
                        // protect value from CG
                        if(param != null && ParamSet.Contains(param))
                        {
                            // protect from GC
                            ParamSet.Add(param);
                        }
                        
                        // make Ninject to return same instance for this argument
                        return param;
                    });
        }
    }
