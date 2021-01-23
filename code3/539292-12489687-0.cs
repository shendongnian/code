        private bool useOptionsDB; 
        private Form1() // private to be sure you don't use it
        {
            InitializeComponent();
        }
        public Form1(bool useOptions)
            : this()
        {
            useOptionsDB = useOptions;
            // your stuff
            if (useOptionsDB)
                mainUrl = OptionsDB.get_changedWebSite();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cl = new ChangeLink();
            cl.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = cl.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                cl.Close();
            }
            else if (dr == DialogResult.OK && useOptionsDB) // <- add check on the bool field
            {
                label4.Text = cl.getText();
                mainUrl = cl.getText();
                OptionsDB.set_changeWebSite(cl.getText());
                cl.Close();
            }
        }
