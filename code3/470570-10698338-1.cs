        bool isChecked =false;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButton1.Checked;
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && !isChecked)
                radioButton1.Checked = false;
            else
            {
                radioButton1.Checked = true;
                isChecked = false;
            }
        }
