        public static List<String> ExtractErrors(this ModelStateDictionary modelStateDictionary)
        {
            var modelErrorCollection = (from modelState in modelStateDictionary.Values
                                        where modelState.Errors != null && modelState.Errors.Count > 0
                                        select modelState.Errors)
                                        .SelectMany(item=>item)
                                        .Select(modelError=>modelError.ErrorMessage)
                                        .ToList();
             return modelErrorCollection;
         }
