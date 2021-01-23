        public void AddValidationsToModelState(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.property, error.message);
            }
        }
