     public Form1()
        {
            InitializeComponent();
            userControl11.OnButtonClicked += new EventHandler<MyEventArgs>(UserCOntrol_ButtonClicked);
        }
        private void UserCOntrol_ButtonClicked(object sender, MyEventArgs e)
        {
            MessageBox.Show(e.AdditionalInfo);
        }
