    Control ctrl = null;     
    
      private void textBox1_Enter(object sender, MouseEventArgs e)
            {
                ctrl = (Control)sender;
            }
      private void textBox2_Enter(object sender, MouseEventArgs e)
            {
                ctrl = (Control)sender;
    
            }
    
    
    private void btn_a_Click(object sender, EventArgs e)
            {
                 if (ctrl != null)
                {
                    TextBox tb = ctrl as TextBox;
                    tb.Text += "a";
                }
                
            }
