    public class KeyEvent
    {
        // You don't need to declare an internal event
        public string key = "";
        private Control _control;
        public KeyEvent(Control control)
        {
            // Here is where we save the reference of Control that was passed to the class.
            // This will enable you to access the instance of the Form or whatever else
            // you want to use, which is helpful for unregistering events during cleanup
            _control = control;
    
            // Wire up your event handler to this SPECIFIC instance of Control.
            // This will cause your `keyPressed` method to execute whenever
            // the control raises the KeyDown event.  All of the middleman
            // event handling you are doing is unnecessary.
            _control.KeyDown += keyPressed;
        }
    
        private void keyPressed(object sender, KeyEventArgs e)
        {
            key = e.KeyCode.ToString();
        }
    }
