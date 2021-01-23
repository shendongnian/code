        private void ImageSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (DialogResult.No == MessageBox.Show("Are you sure you wish to exit?", "Exit Confirmation", MessageBoxButtons.YesNo))
                    e.Cancel = true;
                else { Application.Exit(); }
            }
        }
