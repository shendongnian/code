    public static class ControllerExtensions
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<ValidationResult> validationResults)
        {
            if (validationResults == null) return;
            foreach (var validationResult in validationResults)
            {
                modelState.AddModelError(validationResult.MemberName, validationResult.ErrorMessage);
            }
        }
    }
