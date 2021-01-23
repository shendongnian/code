    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    namespace MySampleComX
    {
        [ComVisible(true)]
        public class Class1
        {
            public void SortIntArray(ref dynamic array)
            {
                if (array.GetType() != typeof(object[])) 
                {
                    throw new ArgumentException("Argument must be an array of integers");
                }
                List<int> intList = ((object[]) array).Select(Convert.ToInt32).ToList();
                intList.Sort();
                array = intList.Select(i => (object)i).ToArray();
            }
        }
    }
