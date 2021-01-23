    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace MvcApplication1.Models
    {
        public abstract class BaseModel
        {
            public string Content { get; set; }
        }
    
        public class ConcreteModel1 : BaseModel { }
        public class ConcreteModel2 : BaseModel { }
        public class ConcreteModel3 : BaseModel { }
    }
