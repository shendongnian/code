    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Web.Http;
    
    namespace ClassLibrary1
    {
        public class TestController : ApiController
        {
            public string Get()
            {
                return "hello from class library2";
            }
        }
    }
