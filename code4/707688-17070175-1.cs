    public interface IViewModelValidator<in TViewModel>
    {
        bool HasError(TViewModel viewModel, ModelStateDictionary modelState);
        bool HasError(TViewModel viewModel, ModelStateDictionary modelState, Action<ModelStateDictionary> callBack);
    }
    public abstract class ViewModelValidatorBase<TViewModel> : IViewModelValidator<TViewModel>
    {
        public abstract bool HasError(TViewModel viewModel, ModelStateDictionary modelState);
        public virtual bool HasError(TViewModel viewModel, ModelStateDictionary modelState, Action<ModelStateDictionary> callBack)
        {
            var hasError = HasError(viewModel, modelState);
            if (hasError && callBack != null)
            {
                callBack(modelState);
            }
            return hasError;
        }
    }
