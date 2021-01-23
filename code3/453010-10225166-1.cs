    private void ShowErrorMessage(string title, string message)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    private void SetControlsToConnectedState()
    {
        UpdateControls(true);
    }
    
    private void SetControlsToDisconnectedState()
    {
        UpdateControls(false);
    }
    
    private void UpdateControls(bool isConnected)
    {
        cmdConnect.Text = isConnected ? "Disconnect" : "Connect";
        cmdItemWrite.Enabled = isConnected;
        cmdItemRead.Enabled = isConnected;
        cmdSyncWrite.Enabled = isConnected;
        cmdSyncRead.Enabled = isConnected;
        cmdAsyncWrite.Enabled = isConnected;
        cmdAsyncRead.Enabled = isConnected;
        cmdAdvise.Enabled = isConnected;
        txtSubValue.Enabled = isConnected;
        cboServer.Enabled = !isConnected;
        txtMachine.Enabled = !isConnected;
        txtGroup.Enabled = !isConnected;
        txtAccessPath.Enabled = !isConnected;
        txtItemID.Enabled = !isConnected;      
    }
    
    private void Disconnect()
    {
        oOpcServer.OPCGroups.RemoveAll();
        oOpcGroup = null;
        oOpcServer.Disconnect();            
    }
    
    private void Connect(string serverName, string machineName)
    {
        switch (serverName)
        {
            case "RSLinx Remote OPC Server":
                if (String.IsNullOrWhiteSpace(machineName))
                {
                    ShowErrorMessage("Connect Error", "Please enter a machine name for remote connection");
                    return;
                }
    
                oOpcServer.Connect(serverName, machineName);                    
                break;
    
            case "RSLinx OPC Server":
                oOpcServer.Connect(serverName);
                break;
    
            default:
                if (String.IsNullOrWhiteSpace(machineName))            
                    oOpcServer.Connect(serverName);            
                else            
                    oOpcServer.Connect(serverName, machineName);            
                break;
        }           
    }
    
    private void DoSomethingWithGroup(string groupName, string accessPath, string itemID)
    {
        oOpcGroup = oOpcServer.OPCGroups.Add(groupName);
        oOpcGroup.IsSubscribed = true;
        oOpcGroup.IsActive = false;
        oOpcGroup.UpdateRate = 1000;
    
        ClHandle = 1;
        oOpcGroup.OPCItems.DefaultAccessPath = accessPath;
        oOpcGroup.OPCItems.AddItem(itemID, ClHandle);
    
        oOpcGroup.DataChange += new RsiOPCAuto.DIOPCGroupEvent_DataChangeEventHandler(oOpcGroup_DataChange);
    }
