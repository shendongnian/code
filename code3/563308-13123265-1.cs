    switch (UserSelection)
    {
        case "Page 1":
            if(curActiveControl.GetType() != typeOf(Page1Control))
            {
                pnlMain.Controls.Remove(curActiveControl);
                curActiveControl = new Page1Control();
                //do setup and configuration things
                pnlMain.Controls.Add(curActiveControl);
            }
            //do some post processing things
            break;
        //other pages/specific page controls
    }
    
    Refresh();
