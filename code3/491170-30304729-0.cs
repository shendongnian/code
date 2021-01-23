Make button1.Enabled = false;
and add EventHandler to textbox1.TextChanged = new System.EventHandler(SearchBoxTextChanged);
    private void textbox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (textBox1.Text.Trim() != string.Empty);
        }
