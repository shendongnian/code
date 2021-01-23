    public class PersonHobbyController : Controller
    {
        //
        // GET: /PersonHobby/
        [HttpGet] // mark as accepting only GET
        public ActionResult Create() // Index should probably provide some summary of people and hobbies
        {
            var model = new PersonHobbyViewModel();
            return View(model);
        }
    
        [HttpPost] // mark as accepting only POST
        public ActionResult Create(PersonHobbyViewModel model) {
    
            if (ModelState.IsValid) {
               var person = new Person { Name = model.Name };
               var hobby = new Hobby { Description = model.Description };
               person.Hobbies = new List<Hobby> { hobby };
    
               db.Persons.Add( person );
               db.SaveChanges();
            }
    
            return RedirectToAction( "details", new { id = person.Id } ); // view the newly created entity
        }
    }
  
