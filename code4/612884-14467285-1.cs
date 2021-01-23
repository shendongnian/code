    public class PartChangeModel { }
    
    public class PartModel { }
    
    public class BOMItemModel { }
    
    public class PartViewModel { }
    
    public class PartController : Controller {
        public ActionResult Get() {
            var partChangeModel = new PartChangeModel { /* init properties via repo, etc. */ }
            var partModel = new PartModel { /* init properties via repo, etc. */ }
            var bomItemModel = new BOMItemModel { /* init properties via repo, etc. */ }
    
            var viewModel = new PartViewModel {
                PartChangeModel = partChangeModel,
                PartModel = partModel,
                BOMItemModel = bomItemModel
            }
    
            return Json(viewModel);
        }
    }
