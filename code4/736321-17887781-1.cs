    public class AVMLocator : MvxDefaultViewModelLocator
    {
        public override bool TryLoad(Type viewModelType, IMvxBundle parameterValues, IMvxBundle savedState, out IMvxViewModel viewModel)
        {
            if (AVM.TryLoadFromBundle(parameterValues, out viewModel))
                return true;
            return base.TryLoad(viewModelType, parameterValues, savedState, out viewModel);
        }
    }
