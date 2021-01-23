       MessageDialog msgDialog = new MessageDialog(R.GetResourceString("Your message"), "Your title");
       
       //OK Button
       UICommand okBtn = new UICommand("OK");
       okBtn.Invoked = OkBtnClick;
       msgDialog.Commands.Add(okBtn);
    
       //Cancel Button
       UICommand cancelBtn = new UICommand("Cancel");
       cancelBtn.Invoked = CancelBtnClick;
       msgDialog.Commands.Add(cancelBtn);
    private void CancelBtnClick(IUICommand command)
    {
    }
    private void OkBtnClick(IUICommand command)
    {
    }
