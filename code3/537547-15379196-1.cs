       MessageDialog msgDialog = new MessageDialog("Your message", "Your title");
       
       //OK Button
       UICommand okBtn = new UICommand("OK");
       okBtn.Invoked = OkBtnClick;
       msgDialog.Commands.Add(okBtn);
    
       //Cancel Button
       UICommand cancelBtn = new UICommand("Cancel");
       cancelBtn.Invoked = CancelBtnClick;
       msgDialog.Commands.Add(cancelBtn);
       //Show message
       msgDialog.ShowAsync();
