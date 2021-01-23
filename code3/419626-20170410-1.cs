    public class BaseRegionNavigationContentLoader : RegionNavigationContentLoader
    {
        private Uri _uri;
        private IServiceLocator _serviceLocator;
        private IUnityContainer _unityContainer;
        public BaseRegionNavigationContentLoader(IServiceLocator serviceLocator, IUnityContainer unityContainer) : base(serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _unityContainer = unityContainer;
        }
        protected override string GetContractFromNavigationContext(NavigationContext navigationContext)
        {
            _uri = navigationContext.Uri;
            return base.GetContractFromNavigationContext(navigationContext);
        }
        protected override object CreateNewRegionItem(string candidateTargetContract)
        {
            object instance;
            try
            {
                var uri = _uri as NavigationUri;
                if (uri == null)
                {
                    instance = _serviceLocator.GetInstance<object>(candidateTargetContract);
                }
                else
                {
                    // Create injection overrides for all the types in the uri
                    var depoverride = new DependencyOverrides();
                    foreach (var supplant in uri)
                    {
                        depoverride.Add(supplant.Key, supplant.Value);
                    }
                    instance = _unityContainer.Resolve<object>(candidateTargetContract, depoverride);
                }
            }
            catch (ActivationException exception)
            {
                throw new InvalidOperationException(string.Format(System.Globalization.CultureInfo.CurrentCulture, "CannotCreateNavigationTarget", new object[] { candidateTargetContract }), exception);
            }
            return instance;
        }
    }
