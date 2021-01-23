        [HttpGet]
        [PopulateTitleDandDate]
        public ActionResult BlogEntry(string title, DateTime createdDate)
        {
            var viewModel = new BlogEntryModel
                {
                    Tittle = title,
                    CreatedDate = createdDate
                };
            return View(viewModel);
        }
