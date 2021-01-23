    private void EnableAllButtons() 
    { 
        //See if the main form needs invoke required, assuming the buttons are on the same thread as the form
        if(this.InvokeRequired) 
        {
            //Calls EnableAllButtons a seccond time but this time on the main thread.
            //This does not block, it is "fire and forget"
            this.BeginInvoke(new Action(EnableAllButtons));
        }
        else
        {
            btnProcessImages.Enabled = true; 
            btnBrowse.Enabled = true; 
            btnUpload.Enabled = true; 
            btnExit.Enabled = true; 
            ControlBox = true;
        }
    }
