    public partial class ControlBase : UserControl
    {
        /// <summary>
        /// Dummy control, use for invoking
        /// </summary>
        public static Control sDummyControl = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlBase()
        {
            InitializeComponent();
            if (sDummyControl == null)
            {
                sDummyControl = new Control();
                sDummyControl.Handle.ToString(); // Force create handle
            }
        }
    }
