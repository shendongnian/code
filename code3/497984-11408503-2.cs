    public class NerdyController : ApiController
    {
        public void Post(string type, Obj o) { 
            throw new Exception("Type=" + type + ", o.Name=" + o.Name ); 
        }
    }
    public class Obj {
        public string Name { get; set; }
        public string Age { get; set; }
    }
