    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult Create(User userData)
        {
            var validator = new UserValidator(UserValidator.Mode.Create);
        
            if (ValidateWrapper(validator, userData, this.ModelState))
            {
                // Put userData in database...
            }
            else
            {
                // ValidateWrapper added errors from UserValidator to ModelState.
                return View();
            }
        }
        private static bool ValidateWrapper<T>(FluentValidation.AbstractValidator<T> validator, T data, ModelStateDictionary modelState)
        {
            var validationResult = validator.Validate(data);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return false;
            }
            return true;
        }
    }
