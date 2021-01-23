     private void Form1_Load(object sender, EventArgs e) {
            DisableControls(this);
            EnableControls(Button1);
        }
        
        private void DisableControls(ref Control con) {
            foreach (Control c in con.Controls) {
                DisableControls(c);
            }
            con.Enabled = false;
        }
        
        private void EnableControls(ref Control con) {
            if (con != null) {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }
