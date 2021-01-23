        private void cmdEnter_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().All(tb => String.IsNullOrEmpty(tb.Text)))
            {
                MessageBox.Show("Textboxes are all empty");
            }
            else
            {
                MessageBox.Show("Entry Added");
            }
        }
