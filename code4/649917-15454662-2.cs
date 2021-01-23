    public partial class addChannel : Form
    {                     
        public addChannel()
        {
            InitializeComponent();
        }
        public Channel SelectedChannel { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            // Save the info to an XML doc
            SelectedChannel = theChannel;
            this.Close();
        }
    }
