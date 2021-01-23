    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        { 
            errorProvider1.Clear();
            if (numericUpDown1.Value == 42)
            {
                numericUpDown1.BackColor = Color.Red;
                errorProvider1.SetError(numericUpDown1, "Select another number");
            }
            else
            {
                numericUpDown1.BackColor = System.Drawing.SystemColors.Window;
            }
        }
