        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar2.Enabled = !checkBox1.Checked;
            textBox8.Enabled = checkBox1.Checked;
            if (checkBox1.Checked)
            {
                button3.PerformClick();
            }
        }
