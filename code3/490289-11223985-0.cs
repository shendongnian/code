	class MyNinjectModule : NinjectModule {
		public override void Load() {
			...
			Bind<IDeployEntityFactory>().To<DeployEntityfactory>().InSingletonScope();
			Bind<IDeployEntityContainer>().To<DeployEntityContainer>();
			...
		}
	}
	
	public class DeployEntityFactory : IDeployEntityFactory
    {
        private readonly IResolutionRoot _resolutionRoot;
		...
        public DeployEntityFactory(..., IResolutionRoot resolutionRoot)
        {
			...
            _resolutionRoot = resolutionRoot;
        }
        public T GetDeployEntity<T>()
        {
            return _resolutionRoot.Get<T>();
        }
    }
