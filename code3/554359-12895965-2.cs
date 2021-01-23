     private void SetProperty(Control ctr)
        {
            foreach(Control control in ctr.Controls)
            {
                if (control is TextBox)
                {
                    //Set Context menu here                  
                }
                else
                {
                    if (control.HasChildren)
                    {
                        SetProperty(control);
                    }                    
                }
            }
        }
