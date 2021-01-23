     private void SetElementsForDisplaying()
        {
            pnlDisplayValues.Visible = true;
            pnlSetValues.Visible = false; 
            litUserTitle.Visible = true; // set this as visible 
            litUserTitle.Text = string.Format("Display profile for {0}", this.Profile.UserName);
    
        }
