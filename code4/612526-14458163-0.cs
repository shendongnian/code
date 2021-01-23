        private void button1_Click(object sender, EventArgs e)
        {
            frmContainer = new Form();
            frmContainer.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmContainer.Height = this.Height / 2;
            frmContainer.Width = this.Width / 2;
            frmContainer.BackColor = Color.Red;
            frmContainer.TopLevel = false;
            this.Controls.Add(frmContainer);
            frmContainer.Show();
            frmContainer.BringToFront();
        }
