    foreach(Control c in PageControls)
    {
        if(!(c is Button))
        {
            c.Enabled = false;
         }
     }
