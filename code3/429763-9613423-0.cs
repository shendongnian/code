        public class MvcApplication : HttpApplication
    {
        private IUnityContainer unityContainer;
        private HttpContextDisposableLifetimeManager ContextLifeTimeManager;
        /// <summary>
    	/// The start method of the application.
    	/// </summary>
    	protected void Application_Start()
    	{
            unityContainer = new UnityContainer();
            ContextLifeTimeManager = new HttpContextDisposableLifetimeManager();
            //for some reason this event handler registration doesn't work, meaning we have to add code to
            //Application_EndRequest as below...
            //this.EndRequest += new EventHandler(ContextLifeTimeManager.DisposingHandler);
            unityContainer.RegisterType<IUnitOfWork, EFUnitOfWork>(ContextLifeTimeManager);
            unityContainer.RegisterType<IRepository<ShoppingCart>, ShoppingCartRepository>(new ContainerControlledLifetimeManager());
        }
        //this seems hackish, but it works, so whatever...
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            if (ContextLifeTimeManager != null)
            {
                ContextLifeTimeManager.RemoveValue();
            }
        }
    }
