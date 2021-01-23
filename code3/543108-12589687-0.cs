    public class MyController : Controller {
        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id) {
        }
    
        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id) {
            
        }
    }
