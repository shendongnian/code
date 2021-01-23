        private void UserControl1_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.MouseMove += Control_Move;
            }
        }
        protected void Control_Move(object sender, MouseEventArgs e)
        {
            // do stuff here
        }
