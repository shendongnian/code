    public class PaymentsController : ApiController {
            [HttpGet]
            public Person GetValues(string ids = null)
            {
                return new Person() { FirstName = "Michael" };
            }
        }
    
        public class Person
        {
            public string FirstName { get; set; }
        }
    }
