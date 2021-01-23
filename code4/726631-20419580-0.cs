     [HttpPost]
        public ActionResult Create(WebSite website)
        {
            string desc = HtmlAgi(website.Url, "description");
            string keyword = HtmlAgi(website.Url, "Keywords");
            if (ModelState.IsValid)
            {
                var userId = ((CustomPrincipal)User).UserId;
                r.Create(new WebSite
                {
                    Description = desc,
                    Tags = keyword,
                    Url = website.Url,
                    UserId = userId,
                    Category = website.Category
                });
                return RedirectToAction("Index");
            }
            return View(website);
        }
