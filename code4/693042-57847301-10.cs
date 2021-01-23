    public class HomeController : Controller
    {               
       /* A demo action
        public ActionResult Index()
        {           
            return View(model);
        }
       */
        [HttpPost]
        public FileResult ExportData()
        {
            /* An example filter
            var filter = TempData["filterKeys"] as MyFilter;
            TempData.Keep();            */
            var someList = db.GetDataFromDb(/*filter*/) // filter as an example
        /*May be here's the trick, I'm setting my filter in TempData["filterKeys"] 
         in an action,(GetFilteredPartial() illustrated below) when 'searching' for the data,
         so do not really need ajax here..to pass my filters.. */
         
         //Some utility to convert list to Datatable
         var dt = Utility.ConvertToDataTable(someList); 
          //  I am using EPPlus nuget package 
          using (ExcelPackage pck = new ExcelPackage())
          {
              ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
              ws.Cells["A1"].LoadFromDataTable(dt, true);
                
                using (var memoryStream = new MemoryStream())
                {                   
                  pck.SaveAs(memoryStream);
                  return File(memoryStream.ToArray(),
                  "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                  "ExportFileName.xlsx");                    
                }                
            }   
        }
        //This is just a supporting example to illustrate setting up filters ..        
       /* [HttpPost]
        public PartialViewResult GetFilteredPartial(MyFilter filter)
        {            
            TempData["filterKeys"] = filter;
            var filteredData = db.GetConcernedData(filter);
            var model = new MainViewModel();
            model.PartialViewModel = filteredData;
            return PartialView("_SomePartialView", model);
        } */     
    } 
