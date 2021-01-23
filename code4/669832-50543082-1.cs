    public class ModelStateHelper
    {
        public static IEnumerable<KeyValuePair<string, string>> 
             AllErrors(ModelStateDictionary modelState)
        {
            var result = new List<KeyValuePair<string, string>>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });
            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new KeyValuePair<string, string>(fieldKey, error.ErrorMessage)); //Error(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }
            return result;
        }
    }
