        [HttpPost]
        [ValidateInput(false)]
        [ActionName("Search")]
        public virtual ActionResult SearchByPost(SearchViewModel model)
        {
            // irrelevant code snipped
        
            return View(model);
        }
