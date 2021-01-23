     private void YourForm_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.Alt && e.KeyCode == Keys.H)
                {
                    this.Hide();
                }
               else if (e.Control && e.Alt && e.KeyCode == Keys.S)
                {
                    this.Show();
                }
