    public ActionResult ContentManage()
            {
                var _sections = new ContentService().GetSections();
                // ViewBag.SectionsDropdown = _sections; // i prefare to pass data im model
                return View(_sections);
            }
