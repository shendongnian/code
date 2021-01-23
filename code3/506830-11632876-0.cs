       foreach (Control c in this.college.Controls)
        {
            if (c is TextBox)
            {
                TextBox textBox = c as TextBox;
                 if (string.IsNullOrWhiteSpace(textBox.Text))
                 {
                    errorProvider1.SetError(textBox, "Field Empty");
                 }
                 else
                 {
                    errorProvider1.SetError(textBox, "");
                 }
            }
        }
