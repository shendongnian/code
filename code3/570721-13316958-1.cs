        [HttpPost]
        public ActionResult Register(Person person){
            if(ModelState.IsValid){
                RepopulateSelectLists(); //Gets the data for the select list again
                var previewVM = new PreviewVM();
                // populate it with the model or whatever else you need for the preview
                return View("Preview", previewVM);
            }
            return View();
        }
