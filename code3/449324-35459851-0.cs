        Form1.Autovalide = Disabled
        
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
           if (textBox2.Text.Length == 0)
           {
              errorProvider1.SetError(textBox2, "Must provide an entry.");
              e.Cancel = true;
           } else {
              errorProvider1.SetError(textbox2, "");
           }
        }
        
        private void button1_click(object sender, EventArgs e)
        {
           if (this.ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.ImmediateChildren))
           {
              MessageBox.Show("All's well.", "Valid", MessageBoxButtons.OK);
           }  else {
              MessageBox.Show("All is ruin and woe!", "Invalid", MessageBoxButtons.OK);
           }
    }
