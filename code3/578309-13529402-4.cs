    protected void btnUpdateClick(object sender, DirectEventArgs e)
    {
            MessageBoxButtonConfig buttonYes = new MessageBoxButtonConfig();
            buttonYes.Text = "Yes";
            buttonYes.Handler = "Ext.net.DirectMethods.ClickedYES();";
          
            MessageBoxButtonConfig buttonNo = new MessageBoxButtonConfig();
            buttonNo.Text = "NO";
            //  buttonNo.Handler = "Ext.net.DirectMethods.ClickedNO();";
            MessageBoxButtonsConfig yesNoButtons = new MessageBoxButtonsConfig();
            yesNoButtons.Yes = buttonYes;
            yesNoButtons.No = buttonNo;
            X.Msg.Confirm("Save Changes", "Would you like to Save?", yesNoButtons).Show();
     }
