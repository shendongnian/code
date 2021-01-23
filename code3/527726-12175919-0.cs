    public class ConfidenceLvl
        {
            public string IpVal { get; set; }
            public string IspVal { get; set; }
            public string ConLvlVal { get; set; }
        }
    
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                IList<ConfidenceLvl> levels = new List<ConfidenceLvl>();
                levels.Add(new ConfidenceLvl { IpVal = "129.123.123.123", ConLvlVal = "1", IspVal = "AOL" });
                levels.Add(new ConfidenceLvl { IpVal = "129.123.0.0", ConLvlVal = "3", IspVal = "CompuServe" });
                
                // Controlled json
                return Json(levels.Select(lv => new { title = lv.IspVal, ip = lv.IpVal }));
    
                // As it comes json
                //return Json(levels);
            }
        }
    }
