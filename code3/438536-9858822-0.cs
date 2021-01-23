    using System;
    using System.Runtime.InteropServices;
    namespace MySampleComX
    {
        [ComVisible(true)]
        public class Class1
        {
            public int Sum(object[] values)
            {
                int result = 0;
                foreach (object o in values)
                {
                    result += Convert.ToInt32(o);
                }
                return result;
            }
        }
    }
