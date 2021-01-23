    namespace MvcApplication1.Models
    {
        using System.Web.Mvc;
    
        public class BaseModel
        {
    
            public string BaseProp { get; set; }
    
            [HiddenInput(DisplayValue = false)]
            public virtual string Type
            {
                get
                {
                    return _type ?? this.GetType().FullName;
                }
                set
                {
                    _type = value;
                }
            }
            private string _type;
        }
    
        public class FooModel : BaseModel
        {
            public string FooProp { get; set; }
        }
    
        public class BarModel :BaseModel
        {
            public string BarProp { get; set; }
        }
    }
