    public partial class MainWindow : Form
    {
        private OtherWindow m_otherWindow;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Lazy create other window if it doesn't exist.
            m_otherWindow = m_otherWindow ?? new OtherWindow();
            // Passe textbox value to other window.
            m_otherWindow.PassedValue=textBox1.Text;
            if (m_otherWindow.ShowDialog()==DialogResult.OK)
            {
                // Clicked ok : update textbox value with textbox value of other window.
                textBox1.Text=m_otherWindow.PassedValue;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    public partial class OtherWindow : Form
    {
        /// <summary>
        /// Value to be passed to the window.
        /// </summary>
        public string PassedValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public OtherWindow()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
