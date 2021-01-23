    // update the user control
    public class MyUserControl : UserControl
    {
        // add the delegate property to your user control
        public event MyEventHandler OnSomeButtonPressed;
    
        // trigger the event when the button is pressed
        protected void MyButton_Click(object sender, EventArgs e)
        {
            string someString = string.Empty;
            if (this.OnSomeButtonPressed != null)
            {
                someString = this.OnSomeButtonPressed(this, e);
            }
    
            // do something with the string
        }    
    }
