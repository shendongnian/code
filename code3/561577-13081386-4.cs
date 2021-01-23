    public class NInjectControllerFactory : DefaultControllerFactory 
    {
        private IKernel kernel = new StandardKernel(new CustomModule());
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);  
        }
        public class CustomModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<ICompetitionRepository>().To(typeof(CompetitionRepository))
                    .WithConstructorArgument("serviceContext", new InMemoryDataContext<Competition>());
                this.Bind<ISubmissionRepository>().To(typeof(SubmissionRepository))
                    .WithConstructorArgument("serviceContext", new InMemoryDataContext<Submission>());
                this.Bind<IUserRepository>().To(typeof(UserRepository))
                    .WithConstructorArgument("serviceContext", new InMemoryDataContext<User>());
                this.Bind<ISuggestionRepository>().To(typeof(SuggestionRepository))
                   .WithConstructorArgument("serviceContext", new InMemoryDataContext<Suggestion>());
            }
        }
    }
