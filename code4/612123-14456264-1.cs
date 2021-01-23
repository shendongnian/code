    public class CarModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarFactory>()
                .ToFactory(() => new UseFirstArgumentAsNameInstanceProvider());
            
            Bind<ICar>()
                .To<Mercedes>()
                .Named("Mercedes");
                
            Bind<ICar>()
                .To<Ferrari>()
                .Named("Ferrari");
        }
    }
