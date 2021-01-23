       public class NinjectDependencyResolver : IDependencyResolver {
    	private IKernal _kernel;
      
        public NinjectDependencyResolver(){
    		_kernal = StandardKernal();
    		AddBindings();
    	}
    
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
    
        public object GetService(Type serviceType)
         {
             return _kernel.TryGet(serviceType);
         }
    
         public IEnumerable<object> GetServices(Type serviceType)
         {
            return _kernal.GetAll(serviceType);
         }
    
    	public IBindingToSyntax<T> Bind<T>() {
    	  return _kernal.Bind<T>();
    	}
    	
         public static void RegisterServices(IKernel kernel){
          //Add your bindings here. 
          //This is static as you can use it for WebApi by passing it the IKernel
    	 }
    }
