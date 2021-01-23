        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
                
        }
