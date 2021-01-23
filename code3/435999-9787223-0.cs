    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace LearnThread
    {
        class Delay
        {
            static int i=0;
    
            public int timePass()
            {
                for(i=0; i<100;i++)
                {
                    Thread.Sleep(1000);
                }
                return i;
            }
        }
    }
