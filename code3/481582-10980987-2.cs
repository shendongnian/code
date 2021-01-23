        decimal numvalue = 0;
        private void numericUpDown1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && numvalue != numericUpDown1.Value)
            {
                //expensive routines
                MessageBox.Show(numericUpDown1.Value.ToString());
            }
            numvalue = numericUpDown1.Value;
        }
