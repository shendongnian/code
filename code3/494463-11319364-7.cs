    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;
    
    namespace JSSerializerSample.Models
    {
        public abstract class BaseViewModel
        {
            public string AsJson()
            {
                var serializer = new JavaScriptSerializer();
                return serializer.Serialize(this);
            }
        }
    }
