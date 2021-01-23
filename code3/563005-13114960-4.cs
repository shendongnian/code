    namespace MvcApplication1.Models
    {
        using System.Web.Mvc;
    
        public class BaseModel
        {
    
            public string BaseProp { get; set; }
    
            [HiddenInput(DisplayValue = false)]
            public virtual string Type { get; set; }
        }
        public class FooModel : BaseModel
        {
            public override string Type
            {
                get
                {
                    return typeof(FooModel).FullName;
                }
            }
        }
        public class BarModel :BaseModel
        {
            public override string Type
            {
                get
                {
                    return typeof(BarModel).FullName;
                }
            }
        }
    }
