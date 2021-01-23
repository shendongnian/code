    public Action(IncomingViewModel incomingViewModel)
    {
        var viewModel = new ViewModel();
        //incoming Date has different name than outgoing date
        viewModel.Date2 = incomingViewModel.OldDate2;
        return viewModel;
    }
