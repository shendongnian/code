    public partial class MyControl
    {
        // Define a delegate that specifies the parameters that will be passed to the user-provided Upload method
        public delegate void DoUploadDelegate(... parameters ...);
        private readonly DoUploadDelegate _uploadDelegate;
        public MyControl(DoUploadDelegate uploadDelegate)
        {
            _uploadDelegate = uploadDelegate;
            InitializeComponent();
        }
        // ...
        // Upload button Click event handler
        public void UploadButtonClicked(object sender, EventArgs e)
        {
            // Call the user-provided upload handler delegate with the appropriate arguments
            _uploadDelegate(...);
        }
    }
