    private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                    TextBox textBox = c as TextBox;
                    if (textBox != null) textBox.Visible = true; 
            }
        }
