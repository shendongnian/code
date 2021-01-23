    protected void Button1_Click(object sender, EventArgs e)
        {
            DisplayControl(Page.Controls);
    
         }
    
        private void DisplayControls(ControlCollection controls)
        {
            
            foreach (Control ctrl in controls)
            {
                Response.Write(ctrl.GetType().ToString() + "  , ID::" +  ctrl.ID + "<br />");
                
               // check for child controls
                if (ctrl.Controls != null)
                    DisplayControls(ctrl.Controls);
            }
    
        }
