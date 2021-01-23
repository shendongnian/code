    using StructureMap; 
    public class StructureMapControllerFactory : DefaultControllerFactory { 
        protected override IController GetControllerInstance(Type controllerType) {
            try {
               return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException) {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
    protected void Application_Start() {
        RegisterRoutes(RouteTable.Routes);
        //Configure StructureMapConfiguration
        // TODO: config structuremap        
        //Set current Controller factory as StructureMapControllerFactory
        ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory()); 
    }
 
