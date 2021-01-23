         private void Form1_KeyPress(object sender, KeyPressEventArgs e)
       
        {  
           if (btnclock.Text == "Start")
                e.Handled = false ;
             else
            {
             i = Convert.ToInt16(rtb1.Text.IndexOf(e.KeyChar));
                if (i == 0)
                {
                    rtb1.Text = rtb1.Text.Remove(0, 1);
                }
                else
                    j++;
                textBox1.Text = Convert.ToString((j));
            }
        }
