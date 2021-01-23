    using System;
    ...
    namespace WindowsFormsApplication1
    {
        class userIn
        {
            bool pressed = false;
            public userIn()
            {
            }
            public bool checkPress() // This method
            {
                return pressed;
            } // Must close here, not end of class
            .
            . 
            .
            private void key1_Click(object sender, EventArgs e)
            {
                pressed = true;
            }
        }
    }
