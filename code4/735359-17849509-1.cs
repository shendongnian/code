    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Web;
    
    namespace MyCustomExtensionService
    {
        public class MyParameterInspector : IParameterInspector
        {
    
            public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
            {
                //throw new NotImplementedException();
            }
    
            public object BeforeCall(string operationName, object[] inputs)
            {
                MethodInfo method = typeof(Service1).GetMethod(operationName);
                Attribute[] attributes = Attribute.GetCustomAttributes(method, typeof(UserAccessAttribute), true);
    
                var attr = (UserAccessAttribute)attributes.First();
    
                if (attributes.Any())
                {
                    var userHasProperAuthorization = true;
                    if (attr.GetUserRole() == "Residents" && userHasProperAuthorization)
                    {
                        //everything is good, continue to operation
                    }
                    else
                    {
                        throw new FaultException("You do not have the right security role!");
                    }
                }
    
                
    
                return null;
    
            }
        }
    }
