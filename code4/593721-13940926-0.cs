    bool buttonpressed = false;
    private void KeyDown_Event(object s, System.Windows.Forms.KeyEventArgs e)
    {
       if(e.KeyCode == KeyCode.Space)
          buttonpressed = true;
       else
          buttonpressed = false;
    }
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (buttonPressed)
                    {
                        /* Do modified behavour for left mouse being held down while 
                        space is also held down */
                    }
                    else
                    {
                        // Do normal behavour for left mouse being held down
                    }
    
                }
            }
