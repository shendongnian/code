            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Action", Value = "0" });
            items.Add(new SelectListItem { Text = "Drama", Value = "1" });
            items.Add(new SelectListItem { Text = "Comedy", Value = "2" });
            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });
            ViewData["Sites"] = items;
