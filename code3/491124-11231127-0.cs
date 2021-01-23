     private void btok_Click(object sender, EventArgs e)
        {
            if (dtpickerend.Value == dtpickerstart.Value)
                MessageBox.Show("Please select an interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                Program.date_start = dtpickerstart.Value;
                Program.date_end = dtpickerend.Value;
                this.DialogResult = DialogResult.OK
                this.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
