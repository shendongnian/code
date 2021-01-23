    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace WindowsFormsApplication1
    {
        class userIn
        {
            bool pressed = false;
            public userIn()
            {
    
            }
    
            public bool checkPress() //Error    9   'WindowsFormsApplication1.userIn.checkPress()': not all code paths return a value   C
            {  //<---- it is teling me that a closing bracket is expected here?
                private void key5_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void keyb_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key0_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void keya_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void keye_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key9_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key8_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key7_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void keyd_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void keyf_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key6_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key4_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void keyc_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key3_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key2_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
    
                private void key1_Click(object sender, EventArgs e)
                {
                    pressed = true;
                }
                return pressed; //Error 6   Invalid token 'return' in class, struct, or interface member declaration
            }
        }
