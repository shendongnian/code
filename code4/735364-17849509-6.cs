    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    
    namespace MyCustomExtensionService
    {
       
        public class Service1 : IService1
        {
            [UserAccess("Residents")]
            public string GetData(int value)
            {
                return string.Format("You entered: {0}", value);
            }
    
            [UserAccess("Admin")]
            public string GetDataUsingWrongUserAccess(int value)
            {
                return string.Format("You entered: {0}", value);
            }
        }
    }
