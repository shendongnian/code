        public static IUnityContainer RegisterIfUnRegistered<TAbstraction, TImplementation>(
             this IUnityContainer container) where TImplementation : TAbstraction 
        {
            if (!container.IsRegistered <TAbstraction>())
            {
                container.RegisterType<TAbstraction, TImplementation>();
            }
            return container; //Make it fluent
        }
