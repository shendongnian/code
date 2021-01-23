    public class PhpRedirectController : Controller
    {
        [HttpGet]
        public ActionResult Get(string path)
        {
            // TryGetNewUrl should be implemented to perform the
            // mapping, or return null is there is none.
            string newUrl = TryGetNewUrl(path);
            if (newUrl == null)
            {
                // 404 not found
                return new HttpNotFoundResult();
            }
            else
            {
                // 301 moved permanently
                return RedirectPermanent(newUrl);
            }
        }
    }
