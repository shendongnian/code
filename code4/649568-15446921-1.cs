    public MainMovement : Form
    {
        public event EventHandler Updated;
        private void OnUpdateStatus()
        {
            if (Updated != null)
            {
                Updated(this, new EventArgs());
            }
        }
        private String updatestatus;
        public String UpdateStatus
        {
            get { return updatestatus; }
            private set 
            {
                updatestatus = value;
                OnUpdateStatus();
            }
        }
        // rest of your child form code 
    }
    public ParentForm : Form
    {
        public void MethodInYourExample()
        {
            // other code?
            MainMovement child = new MainMovement(new_dat, required_time, number);
            child.Updated += ChildUpdated;
            child.TopLevel = false;
            this.pnlmain.Controls.Add(child);
            child.Show();
            child.BringToFront();
        }
        void ChildUpdated(object sender, EventArgs e)
        {
            var child = sender as MainMovement;
            string updatingc = child.UpdateStatus;
            //rest of your code
        }
    }
