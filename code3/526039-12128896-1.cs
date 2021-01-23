     protected IEnumerable<string> GetErrorsFromModelState() {
            var errors = ModelState
             .SelectMany(x => x.Value.Errors.Where(error=>!String.IsNullOrEmpty(error.ErrorMessage)).Select(error => error.ErrorMessage)
             .Union(x.Value.Errors.Where(error=>!String.IsNullOrEmpty(error.ErrorMessage)).Select(error => error.Exception.Message)));
            return errors;
        }
