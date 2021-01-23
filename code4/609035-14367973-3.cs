    public class MyViewModelLocator
        : MvxDefaultViewModelLocator
    {
        public override bool TryLoad(Type viewModelType, IDictionary<string, string> parameterValueLookup,
                                     out IMvxViewModel model)
        {
            if (viewModelType == typeof(EditConfigurationViewModel))
            {
                string id;
                if (parameterValueLookup.TryGetValue("id", out id))
                {
                    model = new EditConfigurationViewModel(id);
                }
                else
                {
                    model = new EditConfigurationViewModel();
                }
                return true;
            }
            return base.TryLoad(viewModelType, parameterValueLookup, IMvxViewModel model);
        }
    }
