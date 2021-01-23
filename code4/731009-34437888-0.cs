    public ActionResult LoadCountries()
    {
         List<SelectListItem> li = new List<SelectListItem>();
         li.Add(new SelectListItem { Text = "Select", Value = "0" });
         li.Add(new SelectListItem { Text = "India", Value = "1" });
         li.Add(new SelectListItem { Text = "Srilanka", Value = "2" });
         li.Add(new SelectListItem { Text = "China", Value = "3" });
         li.Add(new SelectListItem { Text = "Austrila", Value = "4" });
         li.Add(new SelectListItem { Text = "USA", Value = "5" });
         li.Add(new SelectListItem { Text = "UK", Value = "6" });
         ViewData["country"] = li;
         return View();
    }
