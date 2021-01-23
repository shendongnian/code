        [HttpPost]
        public ActionResult Standard(Standard model)
        {
            var valContext = new ValidationContext(model, null, null);
            var valResults = new List<ValidationResult>();;
            bool b = Validator.TryValidateObject(model, valContext, valResults, true);
            if(!b)
                return View(model);
            ...
