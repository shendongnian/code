    public void Method() 
    { 
        if (flagIsUp) 
        { 
             if (x == 1)
             {
                //code here; 
                // Excecution skips to 'x==1 fastforward'
             }
             else
             {
                 if (y == 2) // intentional indentation
                 {
                     //code here;
                     // Excecution skips to 'y==1 fastforward'
                 } 
                 else
                 {
                     if (z == 3) // intentional indentation
                     {
                         //code here;
                     }
                 } // y==2 fast forward
             } // x==1 fast forward
        } 
     
        if (buttonPressed) 
        { 
             code here; 
        } 
    } 
