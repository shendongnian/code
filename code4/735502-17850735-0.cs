    public ActionResult submittedvalues()
            {
                var model = new MvcSampleApplication.Models.category();
                string data = ViewData["logindata"] != null ? ViewData["logindata"].ToString() : "";
                model.lablvalue = data;
                return View(model);            
            }
