    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WpfApplication1.Models
    {
        public class Line
        {
            private int x;
            private int y;
    
            public String Name { get; set; }
    
            public int X
            {
                get
                {
                    return x;
                }
                set
                {
                    x = value;
                    XChanged(this, EventArgs.Empty);
                }
            }
    
            public int Y
            {
                get
                {
                    return y;
                }
                set
                {
                    y = value;
                    YChanged(this, EventArgs.Empty);
                }
            }
    
            public event EventHandler XChanged = delegate { };
            public event EventHandler YChanged = delegate { };
        }
    }
