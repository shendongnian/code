    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                lastFocused.Text = listBox1.SelectedItem.ToString();
            }
        }
