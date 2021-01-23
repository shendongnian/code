           foreach (Control ctrl in yourButtonContainerObject.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Enabled = false;
                }
            }
    
