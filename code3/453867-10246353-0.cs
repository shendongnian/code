    public IMvxCommand GoHomeCommand
    {
        get
        {
            return new MvxRelayCommand(RequestNavigate<HomeViewModel>(true));
        }
    }
