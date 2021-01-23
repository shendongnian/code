    public void ProcessPopup(PopupModel model)
    {
        viewModel.SetModel(model);
        App.Current.Dispatcher.BeginInvoke(
                  new Action(()=>{
                                 mainScreen.ShowPopup(CreatePopup(model)); 
                                 }
                  ));
    }
