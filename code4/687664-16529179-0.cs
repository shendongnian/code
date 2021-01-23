    using System.Net.Http;
    using System.Web.Http;
    namespace MyApi.Controllers
    {
        public class MyType {
            public string type {get; set;}
        }
        public class ObjectsController : ApiController {
            //
            // api/objects/create
            //
            public void Create() {
                // buffer the content to allow the dual reads below
                Request.Content.LoadIntoBufferAsync().Wait();
                // get the body as string to pass along to type-specific methods
                string typedata = Request.Content.ReadAsStringAsync().Result;
                // get the body as a object so we can access its type property
                MyType postedObject = Request.Content.ReadAsAsync<MyType>().Result;
                // decide
                switch (postedObject.type) {
                    case "type1":
                        CreateType1(typedata);
                        break;
                    case "type2":
                        CreateType2(typedata);
                        break;
                    default:
                        // 400 Bad Request would be best, I think.
                        break;
                }
		    }
            private void CreateType1(string type1data) {
                // ... 
            }
            private void CreateType2(string type2data) {
                // ...
            }
        }
    }
