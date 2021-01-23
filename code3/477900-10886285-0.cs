    using (_unityContainer = new UnityContainer())
            {
              _unityContainer
              .RegisterType<IPumaServices, POSiXmlServices>("POSiXml")
              .RegisterType<IPumaServices, TaXmlServices>("TaXml")
              .RegisterType<IPumaNotification, PumaNotification>(
                  new InjectionConstructor(                        // Explicitly specify a constructor
                     new ResolvedParameter<IPumaServices>("TaXml") // Resolve parameter of type 
                  );
            }
