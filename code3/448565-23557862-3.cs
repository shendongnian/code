    public class ModelStateAdapter : IValidationDictionary
    {
        private ModelStateDictionary _modelState;
    
        public ModelStateAdapter(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }
    
        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }
    }
