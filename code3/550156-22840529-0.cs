    public static class NinjectSingletonExtension
    {
        public static CustomSingletonKernelModel<T> SingletonBind<T>(this IKernel i_KernelInstance)
        {
            return new CustomSingletonKernelModel<T>(i_KernelInstance);
        }
    }
    public class CustomSingletonKernelModel<T>
    {
        private const string k_ConstantInjectionName = "Implementation";
        private readonly IKernel _kernel;
        private T _concreteInstance;
        public CustomSingletonKernelModel(IKernel i_KernelInstance)
        {
            this._kernel = i_KernelInstance;
        }
        public IBindingInNamedWithOrOnSyntax<T> To<TImplement>(TImplement i_Constant = null) where TImplement : class, T
        {
            _kernel.Bind<T>().To<TImplement>().Named(k_ConstantInjectionName);
            var toReturn =
                _kernel.Bind<T>().ToMethod(x =>
                                           {
                                               if (i_Constant != null)
                                               {
                                                   return i_Constant;
                                               }
                                               if (_concreteInstance == null)
                                               {
                                                   _concreteInstance = _kernel.Get<T>(k_ConstantInjectionName);
                                               }
                                               return _concreteInstance;
                                           }).When(x => true);
            return toReturn;
        }
    }
