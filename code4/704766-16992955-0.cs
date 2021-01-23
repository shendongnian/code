        private void button1_Click(object sender, EventArgs e)
        {
            frmPopUp frmAdd = new frmPopUp();
            frmAdd.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            frmAdd.Location = new System.Drawing.Point(450, 200);
            frmAdd.Closed += (s, a) =>
            {
                this.Create();
            };
            frmAdd.Show(this);
        }
