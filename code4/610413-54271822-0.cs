    // ------------ WINDOWS FORM'S CLASS ------------------------------------
    public partial class WFEvent : Form
    {
        // ------------ CONSTRUCTOR -----------------------------------------
        public WFEvent()
        {
            // Create Events for Control
            CreateEventsControl(pnlParent);
            // Create Events for Other Controls
            CreateEventsOtherControls(this);
        }
        // ------------ PRIVATE METHODS -------------------------------------
        // Create Events for Parent Control (e.g. a Panel) and Child Controls...
        private void CreateEventsControl(Control control)
        {
            // Create Events for Parent Control
            control.MouseEnter += (sender, e) => { CtlMouseEnter(control); };
            control.Click += (sender, e) => { CtlClick(control); };
            // Create Events for Child Controls...
            CreateEventsControlChildControls(control);
        }
        // Create Events for Parent Control's Child Controls...
        private void CreateEventsControlChildControls(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                // Create Events for Parent Panel's Child Control
                childControl.MouseEnter += (sender, e) => { CtlMouseEnter(control); };
                childControl.Click += (sender, e) => { CtlClick(control); };
                // Create Events for Child Control's Child Controls...
                CreateEventsControlChildControls(childControl);
            }
        }
        // Create Events for Other Control's Parent and Child Controls...
        private void CreateEventsOtherControls(Control control)
        {
            // Create Event for Other Control's Parent Control
            control.MouseEnter += (sender, e) => { CtlOtherMouseEnter(control); };
            //control.Click += (sender, e) => { CtlOtherClick(control); };
            // Create Event for Other Control's Child Control...
            CreateEventsOtherControlsChildControls(control);
        }
        // Create Event for Other Control's Child Controls...
        private void CreateEventsOtherControlsChildControls(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl != pnlParent)
                {
                    // Create Events for Other Control's Child Control
                    childControl.MouseEnter += (sender, e) => { CtlOtherMouseEnter(control); };
	            //childControl.Click += (sender, e) => { CtlOtherClick(control); };
                    // Create Events for Other Control's Child Controls's Child Control...
                    CreateEventsOtherControlsChildControls(childControl);
                }
            }
        }
        // MouseEnter for Controls
        private void CtlMouseEnter(Control control) 
        {
                Code...
        }
        // Click for Controls
        private void CtlClick(Control control) 
        {
                Code...
        }
        // MouseEnter for Other Controls
        private void CtlOtherMouseEnter(Control control) 
        {
                Code...
        }
        // Click for Other Controls
        //private void CtlOtherClick(Control control) 
        //{
        //        Code...
        //}
    }
