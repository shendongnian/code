    using System.Web.Script.Serialization;
    namespace SO11444045.Models
    {
        public class HomeIndex
        {
            public HomeIndex()
            {
                this.Name = "Alfred";
                this.Age = 33;
            }
    
            public string Name { get; set; }
    
            public int Age { get; set; }
    
            public string Me()
            {
                var serializer = new JavaScriptSerializer();
                string json = serializer.Serialize((object)this);
                return json;
            }
        }
    }
