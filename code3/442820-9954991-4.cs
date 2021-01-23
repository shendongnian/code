    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    
    namespace getDictData
    {
        class mydict
        {
            public static Dictionary<string, Bitmap> loadDict()
            {
                Dictionary<string, Bitmap> lookup = new Dictionary<string, Bitmap>();
                Bitmap l1 = new Bitmap(@"C:\1\1.bmp", true); lookup.Add("1", l1);
                return lookup;
            }
        }
    }
