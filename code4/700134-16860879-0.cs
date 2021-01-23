     private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//this is working
            {
                    trackBar2.Enabled = false;
                    button3.PerformClick();
                    textBox8.Enabled = true;
            }
            else if(checkBox1.Checked == false)
            {
                trackBar2.Enabled = true;
                textBox8.Enabled = false;
            }
        }
