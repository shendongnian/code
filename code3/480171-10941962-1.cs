    using System.Web.Http;
    using System.Collections.Generic;
    using StackOverflowSplitStringAttribute.Infrastructure.Attributes;
    
    namespace StackOverflowSplitStringAttribute.Controllers
    {
        public class CsvController : ApiController
        {
    
            // GET /api/values
    
            [SplitString(Parameter = "data")]
            public IEnumerable<string> Get(IEnumerable<string> data)
            {
                return data;
            }
        }
    }
