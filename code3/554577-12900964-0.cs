    $.ajax({
        type: 'POST',
        url: urlToYourMvcAction,
        data: {
            name: 'John Doe',
            age: 25
        }, 
        success: successCalback,
        error: errorCallback);
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; ;set }
        public int Age { get; set; }
    }
    public class PersonController : Controller
    {
        [HttpPost]
        public ActionResult Add(Person person)
        {
              //Your code
        }
    }
