    public class BaseController : Controller
    {
        [NonAction]
        protected virtual ActionResult HandlePost<T>(T model, Action<T> processValidModel)
        {
            if (ModelState.IsValid)
            {
                processValidModel(model);
                return RedirectToAction("Main");
            }
            else
            {
                return View(model);
            }
        }
    }
