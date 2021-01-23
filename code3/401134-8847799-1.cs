    public class DerivedController : BaseController
    {
        [HttpPost]
        public ActionResult Create(Person person)
        {
           return HandlePost(person, p => _repository.Save(p));
        }
    }
