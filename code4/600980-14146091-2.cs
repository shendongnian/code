    public ActionResult ApproveItems()
        {
            Utility ut = new Utility();
            IEnumerable<Item> items;
            items = ut.GetAllDistrictItems();
            return View(items.ToList());
        }
