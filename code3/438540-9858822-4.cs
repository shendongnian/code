    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    namespace MySampleComX
    {
        [ComVisible(true)]
        public class Class1
        {
            public void SortIntArray(ref object array)
            {
                if (array.GetType() != typeof(object[])) 
                {
                    throw new ArgumentException("Argument must be an array of integers");
                }
                array = ((object[]) array).OrderBy(Convert.ToInt32).ToArray();
            }
        }
    }
