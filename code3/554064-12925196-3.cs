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
    
            public bool checkPress()
            {               
                return pressed;
            }
            private void key5_Click(object sender, EventArgs e)
            {
                pressed = true;
            }
            //And some other methods
        }
    } //<-- Yes, you sill need that one
