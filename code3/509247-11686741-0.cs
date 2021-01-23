        public ActionResult InitPageNav(int? id) //id is now a nullable int type
        {
              if(!id.HasValue) //id parameter is set ?
              {
                    //return some default partial view or something 
              }
              PageModel page = PageNavHelper.GetPageByID(id);
              return PartialView("UserControls/_PageNavPartial", page);
        }
