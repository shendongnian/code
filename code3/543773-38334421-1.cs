        private void RegisterMouseEvents(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Subscribe the control to the 
                control.Click += Control_MouseClick;
                if (control.HasChildren) RegisterMouseEvents(control.Controls);
            }
        }
