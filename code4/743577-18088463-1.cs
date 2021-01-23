    public class FormsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<FormAStrategy>().ToSelf();
            Bind<FormBStrategy>().ToSelf();
            Bind<Func<string, IPFormDataStrategy>>().ToMethod(context => 
                new Func<string, IPFormDataStrategy>(formName => {
                    switch (formName)
                    {
                        case "FormA": 
                            return context.Kernel.Get<FormAStrategy>();
                            // Note, could also simply "return new FormAStrategy()" here.
                        case "FormB": 
                            return context.Kernel.Get<FormBStrategy>();
                        default: 
                            throw new InvalidOperationException(formName + " is unrecognized");
                    }
                })
            );
        }
    }
