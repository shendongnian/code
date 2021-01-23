    public class MyControl : System.Windows.Forms.UserControl
    {
        // Don't forget to define myPicture here
        ////////////////////////////////////////
        // Declare delegate for picture clicked.
        public delegate void PictureClickedHandler();
        // Declare the event, which is associated with the delegate
        [Category("Action")]
        [Description("Fires when the Picture is clicked.")]
        public event PictureClickedHandler PictureClicked;
        // Add a protected method called OnPictureClicked().
        // You may use this in child classes instead of adding
        // event handlers.
        protected virtual void OnPictureClicked()
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (PictureClicked != null)
            {
                PictureClicked();  // Notify Subscribers
            }
        }
        // Handler for Picture Click.
        private void myPicture_Click(object sender, System.EventArgs e)
        {
            OnPictureClicked();
        }
    }
