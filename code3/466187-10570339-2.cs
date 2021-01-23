        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to cancel and discard all data?", "Think twice!",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
            // Form wont close if anything else is clicked
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            // PerformAction()
            this.Close();
        }
