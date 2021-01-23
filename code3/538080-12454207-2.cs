    [HttpPost]
        public ActionResult Search(MyModel model)
        {
            model.GetCollection();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_listItems", model.SomeCollection);
            }
            else
            {           
                string filename = model.GetExcel();
                string save_path = AppDomain.CurrentDomain.BaseDirectory + "Content/Personal/" + filename;
                HttpContext.Response.Clear();
                HttpContext.Response.ClearContent();
                HttpContext.Response.ClearHeaders();
                HttpContext.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
                HttpContext.Response.ContentType = "application/excel";
                HttpContext.Response.WriteFile(save_path);
                HttpContext.Response.End();
                System.IO.File.Delete(save_path);
                return new EmptyResult();
            }              
            
        }
