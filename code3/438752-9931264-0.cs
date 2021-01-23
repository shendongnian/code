    public class NotesController : Controller {
        public ActionResult Edit(int contactModelId) {
            var result = Repository.ContactModel.Where(x => x.ContactModelId).Select(x => x.Notes);
            return View(result);
        }
    }
