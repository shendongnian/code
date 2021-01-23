        public class NamedController : ApiController
        {
            [HttpPost]
            public int NamedMethod([FromBody] string value)
            {
                return value == null ? 1 : 0;
            }
        }
