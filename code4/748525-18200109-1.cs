    //add some buttons.
    TaskBar.Buttons.Add(new ToolBarButton()); //index 0
    TaskBar.Buttons.Add(new ToolBarButton()); //index 1
    //add the handler
    TaskBar.ButtonClick += new ToolBarButtonClickEventHandler (
        this.taskbar_ButtonClick);
    private void taskbar_ButtonClick (Object sender, ToolBarButtonClickEventArgs e)
    {
        // Evaluate the Button property to determine which button was clicked. 
        switch(TaskBar.Buttons.IndexOf(e.Button))
        {
            case 0:
                //Whatever you want to do when the 1st toolbar button is clicked
                break; 
            case 1:
                //Whatever you want to do when the 2nd toolbar button is clicked
                break; 
        }
    }
