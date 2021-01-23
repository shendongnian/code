      private IList getBobjects()
            {
            List<B> bs = new List<B>();
            bs.Add(new B() { ID = 1, CategoryNumber = 2, 
                 CategoryDescription = "Config 1" });
            bs.Add(new B() { ID = 2, CategoryNumber = 3, 
                 CategoryDescription = "Config 2" });
            return bs;
            }
        public IList<SelectListItem> GetDropdownlistItems()
        {
            IList<SelectListItem> ilSelectList = new List<SelectListItem>();
            IList objlist = getBobjects();
            foreach (object[] arrobject in objlist)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = arrobject[0].ToString();
                selectListItem.Text = arrobject[1].ToString();
                ilSelectList.Add(selectListItem);
            }
            return ilSelectList;
        }
        public ActionResult Create()
        {
            IList<SelectListItem> ilSelectListItems = GetDropdownlistItems();
            ViewBag.bs = ilSelectListItems;
            return View();
        } 
