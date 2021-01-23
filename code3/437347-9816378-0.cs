        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = compute(this.Controls);
        }
        private string compute(Control.ControlCollection controls)
        {
            string result = String.Empty;
            foreach (Control control in controls)
            {
                if (control.Controls != null)
                    result += compute(control.Controls);
                if (control is RadioButton || control is CheckBox)
                {
                    dynamic checkControl = control;
                    if (checkControl.Checked)
                    {
                        result += checkControl.Text + ";";
                    }
                }
            }
            return result;
        }
