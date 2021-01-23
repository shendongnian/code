    public class MyController: Controller
    {
        protected AssetManagerContext db;
        [HttpGet]
        public ActionResult Edit(int id)
        {
            MyAsset myAsset = db.Assets.Find(id); // Used and not disposed
            return View(myAsset);
        }
        protected override void OnActionExecuting(ActionExecutingContext db) {
            base.OnActionExecuting(db);
            db = new AssetManagerContext("ConnectionString");
        }
        protected override void OnActionExecuted(ActionExecutedContext db) {
            base.OnActionExecuted(db);
            db.Dispose();
        }
    }
