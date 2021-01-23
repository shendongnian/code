        // This event triggers when the user closes the form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to cancel and discard all data?",       "Think twice!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                // This will cancel the event and the form will not close
                e.Cancel = false;
            }
        }
