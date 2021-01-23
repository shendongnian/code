        [HttpGet]
        public FileContentResult GetCalenderView()
        {
            var viewData = ViewData; // Ideally copy this or make a fake of it
            viewData.Model = new object(); // Make this the model you want to pass in
            StringWriter sw = new StringWriter();
            ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, "GetCalenderView");
            // Note that we're passing in viewData instead of ViewData
            ViewContext viewContext = new ViewContext(this.ControllerContext, viewResult.View, viewData, this.TempData, sw);
            viewResult.View.Render(viewContext, sw);
            var stringResult = sw.GetStringBuilder().ToString();
            byte[] byteArray = Encoding.ASCII.GetBytes(stringResult);
            return File(byteArray, "application/octet-stream", "Month.xls");
        }
