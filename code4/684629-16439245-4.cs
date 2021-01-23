    public class CrimesController : Controller
    {
        public ActionResult Index()
        {
            var model = new LocalCrimeModel();
            model.Crimes = GetCrimes(); // THIS SHOULD BE A RESULT OF A DATABASE QUERY
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(LocalCrimeModel model)
        {
            if (model != null)
            {
                model = new LocalCrimeModel(); // just to be sure
            }
    
            model.Crimes = GetCrimes(); // USE THE SAME QUERY HERE
    
            if (model != null && model.SelectedCrime != null)
            {
                var db = new FGEntities();
    
                var g = db.UserGangster.FirstOrDefault(p => p.UserProfile.UserName == User.Identity.Name);
    
                g.GansterStatistic.CrimesSuccess++;
    
                g.Experience += model.SelectedCrime.Experience;
                g.Cash += model.SelectedCrime.Cash;
                db.SaveChanges();
    
                model.Message = "You commited the crime!";
            }
            else
            {
                model.Message = "Crime does not exist!";
            }
    
            return View(model);
        }
    }
