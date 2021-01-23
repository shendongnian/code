    public class MyPersonController : Controller {
        public ActionResult Index() {
            var people = PersonStore.GetAllPeople();
            return View(people);
        }
        public ActionResult Image(int id) {
            var image = PersonStore.GetPersonImageById(id);
            return BinaryResult(image.Content, image.MimeType);
        }
    }
