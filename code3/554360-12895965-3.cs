     private void SetProperty(Control ctr)
        {
            foreach(Control control in ctr.Controls)
            {
                if (control is TextBox)
                {
                    control.ContextMenu = new ContextMenu();               
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
