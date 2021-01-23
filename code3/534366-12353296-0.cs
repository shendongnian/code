        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
          
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = System.Drawing.Color.FromName(dlg.Color.Name);
            }
        }
