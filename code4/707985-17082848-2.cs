    public class HomeController : Controller
    {
        
        public ActionResult GridRead([DataSourceRequest] DataSourceRequest request, string intEmpky, string intAdrKy, string strCode)
        {
            List<TestModels> models = new List<TestModels>();
            for (int i = 1; i < 6; i++)
            {
                TestModels model = new TestModels();
                model.ID = i;
                model.Name = intEmpky + "_" + intAdrKy + "_" + strCode;
                models.Add(model);
            }
            return Json(models.ToDataSourceResult(request));
        }
        [HttpGet]
        public JsonResult GetCascadeDistrict()
        {
            List<SelectListItem> models = new List<SelectListItem>();
            for (int i = 1; i < 6; i++)
            {
                SelectListItem model = new SelectListItem();
                model.Value = i.ToString();
                model.Text = "text" + i;
                models.Add(model);
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCascadeMarket(string categories, string productFilter)
        {
            List<SelectListItem> models = new List<SelectListItem>();
            for (int i = 1; i < 6; i++)
            {
                SelectListItem model = new SelectListItem();
                model.Value = i.ToString();
                model.Text = "text" + i;
                models.Add(model);
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
