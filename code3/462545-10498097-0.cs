    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace MyNameSpace //Make sure this matches your projects namespace
    {
        class Tools
        {
            //Because this is outside the form that is calling it, you cannot access
            //the actual form or panel where you wish to place the button so instead
            //of returning void (which is nothing) we return the newly created Button
            public static Button NewBtn(string nName, int locX, int locY)
            {
                //I am just guessing what your NewBtn Method does
                //Create a new button to return
                Button returnbutton =new Button();
                //Assign the name and location
                returnbutton.Name=nName;
                returnbutton.Location=new Point(locX,locY);
                //Return it back to the caller
                return returnbutton;
            }
        
            //You can also add Global variables here if you wish as well, though
            //I recommend you limit their use, as they will always be in memory
            public static string dateFormat="yyyy-MM-dd";
        }
    }
