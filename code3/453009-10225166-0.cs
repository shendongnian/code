    private void cmdConnect_Click(object sender, EventArgs e)
    {
        if (cmdConnect.Text == "Disconnect") 
        {
            Disconnect();
            SetControlsToDisconnectedState();
            return;
        }
    
        if (String.IsNullOrWhiteSpace(txtGroup.Text))
            txtGroup.Text = "_Group01";
                    
    
        if (String.IsNullOrWhiteSpace(txtItemID.Text))
        {
            ShowErrorMessage("Connect Error", "Please enter ItemID.");
            return;
        }
    
        if (String.IsNullOrWhiteSpace(cboServer.Text))
        {
            ShowErrorMessage("Connect Error", "Please select and OPC server");
            return;
        }
    
        Connect(cboServer.Text, txtMachine.Text);
        DoSomethingWithGroup(txtGroup.Text, txtAccessPath.Text, txtItemID.Text);
        SetControlsToConnectedState();
    }
