    myContainer.ControlAdded += myContainerControlAdded;
    
    private void Control_Added(object sender, System.Windows.Forms.ControlEventArgs e)
    {
        if(DisableAddControls)
        {
            throw new DisableAddControlsException();
        }
    }
