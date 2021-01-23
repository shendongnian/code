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
                key5.Click += (sender, e)  =>
                {
                    pressed = true;
                };
                return pressed;
            }
        }
    } //<-- you did also miss that one
