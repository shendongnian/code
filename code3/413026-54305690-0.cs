        private void TextBoxFocusIn(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Encrypted value here...")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }
        private void TextBoxFocusOut(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text =="")
            {
                textBox.Text = "Encrypted value here...";
                textBox.ForeColor = Color.Gray;
            }
        }
        private void BindPlaceHolderInTextbox(Panel contentPanel)
        {
             foreach(Control control in contentPanel.Controls)
            {
                if(control.GetType() == typeof(TextBox))
                {
                    control.Text = "Encrypted value here...";
                    control.ForeColor = Color.Gray;
                    control.GotFocus += new System.EventHandler(TextBoxFocusIn);
                    control.LostFocus += new System.EventHandler(TextBoxFocusOut);
                }
            }
        }
