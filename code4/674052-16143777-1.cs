     private void richTextBox1_MouseHover(object sender, EventArgs e)
            {
                double x;
                
    
                if (double.TryParse(richTextBox1.Text, out x))
                {
                    toolTip1.Show(this is a number will appear",richTextBox1);
    
                }
                else
                {
                    toolTip1.Show("this is an alphabet",richTextBox1);
                }
    
            }
