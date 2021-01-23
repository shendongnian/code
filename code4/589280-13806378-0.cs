        private void button1_Click(object sender, EventArgs e)
        {
            UpdateButtons(sender);
        }
        private void UpdateButtons(object sender)
        {
            foreach (var control in this.Controls)
            {
                if ((Button)sender == control)
                    ((Button)sender).BackColor = Color.Yellow;
                else if (control is Button)
                {
                    ((Button)control).BackColor = Color.Red;
                }
            }
        }
