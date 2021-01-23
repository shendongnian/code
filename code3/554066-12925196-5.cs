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
                //And some other methods
                
                return pressed; //Error 6   Invalid token 'return' in class, struct, or interface member declaration
            }
        }
    } // Error 8 Type or namespace definition, or end-of-file expected
