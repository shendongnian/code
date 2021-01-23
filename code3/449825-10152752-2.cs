    public class PupilController : Controller
    {
        [ChildActionOnly]
        public ActionResult DisplayPupilDetail(int pupilId)
        {
            Person person = Data.People.Single(x => x.PersonId == pupilId);
            return View(person);
        }
    }
