     private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < files.Length - 1)
            {
                listBox1.SelectedIndex++;
                timer1.Enabled = false;
            }
            else
            {
                listBox1.SelectedIndex = 0;
                timer1.Enabled = false;
            }            
        }       
