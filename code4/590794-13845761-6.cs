    public abstract partial class MyControl
    {
        private readonly DoUploadDelegate _uploadDelegate;
        protected MyControl()
        {
            InitializeComponent();
        }
        // ...
        // The method that users of the control will need to implement
        protected abstract void DoUpload(... parameters ...);
        // Upload button Click event handler
        public void UploadButtonClicked(object sender, EventArgs e)
        {
            // Call the overridden upload handler with the appropriate arguments
            DoUpload(...);
        }
    }
