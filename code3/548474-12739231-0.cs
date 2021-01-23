    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SoundEditor_V3
    {
        public class Complex
        {
            public double real;
            public double im;
    
            public Complex()
            {
                real = 0;
                im = 0;
            }
           
            public Complex (double newReal, double newIm)
            {
                real = newReal;
                im = newIm;
            }
        }
    }
