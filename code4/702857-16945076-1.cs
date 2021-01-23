    public partial class UserControl2 : UserControl
    {
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                textBox1.Text = value;
            }
        }
        public UserControl2(string LastName, byte[] data)
        {
            InitializeComponent();
            WireAllControls(this);
            this.LastName = LastName;
            try
            {
                using (var stream = new System.IO.MemoryStream(data))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading Image for " + LastName);
            }
        }
        public UserControl2()
        {
            InitializeComponent();
            WireAllControls(this);
        }
        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }
        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty); 
        }
    }
