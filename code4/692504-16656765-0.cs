        Control ctrl = null;
        void ctrl_MouseEnter(object sender, EventArgs e)
        {
            
            If (ctrl == null) 
            {
               button1.Visible = true;
               ctrl = sender; 
            }
        }
        void ctrl_MouseLeave(object sender, EventArgs e)
        {
            If (ctrl != null && ctrl.Equals(sender)) 
            {
               button1.Visible = false;
               ctrl = null; 
            }
        }
