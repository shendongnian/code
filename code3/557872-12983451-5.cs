    public partial class Form1 : Form
    {
        // Static form. Null if no form created yet.
        private static Form1 form = null;
        private delegate void EnableDelegate(bool);
        public Form1()
        {
            InitializeComponent();
            form = this;
        }
        // Static method, call the non-static version if the form exist.
        public static void EnableStaticTextBox(bool enable)
        {
            if (form != null)
                form.EnableTextBox(enable);
        }
        private void EnableTextBox(bool enable)
        {
            // If this returns true, it means it was called from an external thread.
            if (InvokeRequired)
            {
                // Create a delegate of this method and let the form run it.
                this.Invoke(new EnableDelegate(EnableTextBox), new object[] { enable });
                return; // Important
            }
            // Set textBox
            textBox1.Enabled = enable;
        }
    }
