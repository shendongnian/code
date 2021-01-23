    using System;
    using System.Collections.Generic;
    using System.Linq; 
    using System.Text;
    using System.Windows.Forms; 
    namespace WindowsFormsApplication1
    {
        class SomethingButton : Button
        {
            public Something mySomething
            { get; set; }
        }
        public class Something
        {
            public String isBetterThan { get; set; }
            public String Author { get; set; }
        }
    }
