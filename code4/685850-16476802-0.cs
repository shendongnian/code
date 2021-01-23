     public HelpViewModel (string helpKey)
     {
           CustomTextSource = new MvxLanguageBinder(Constants.GeneralNamespace, helpKey);
     }
     public IMvxLanguageBinder CustomTextSource { get; private set; }
