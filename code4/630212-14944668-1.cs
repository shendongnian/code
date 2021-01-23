    RegisterViewModel registerViewModel;
    RegisterSellerViewModel sellerModel; 
    if (registerViewModelObject is RegisterViewModel)
    {
        registerViewModel = (RegisterViewModel)registerViewModelObject;
    }
    else
    {
        sellerViewModel = (RegisterSellerViewModel)registerViewModelObject;
    }
