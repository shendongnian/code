            if (MessageBox.Show(this, "Do you want to close the Application?", "Exit App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //close app code
            }
