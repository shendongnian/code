    using System;
    using System.Runtime.InteropServices;
    namespace InteropTest
    {
        class InteropTest
        {
            [DllImport("testlib.dll")]
            private static extern int myFunction(int someNumber, out int arraySize, out IntPtr array);
            [DllImport("testlib.dll")]
            public static extern int freePointer(IntPtr pointer);
            public static byte[] myFunction(int myNumber)
            {
                int myArraySize;
                IntPtr pointerToArray;
                int iRet = myFunction(myNumber, out myArraySize, out pointerToArray);
                // should check iRet and if needed throw exception
                #if (DEBUG)
                    Console.WriteLine();
                    Console.WriteLine("InteropTest.myFunction myArraySize: {0}", myArraySize);
                    Console.WriteLine();
                #endif
                byte[] myArray = new byte[myArraySize];
                Marshal.Copy(pointerToArray, myArray, 0, myArraySize);
                freePointer(pointerToArray);
                #if (DEBUG)
                   Console.WriteLine();
                #endif
                return myArray;
            }
            static void Main(string[] args)
            {
                #if (DEBUG)
                    Console.WriteLine("Start InteropTest");
                    Console.WriteLine();
                #endif
                int myNumber = 123;
                byte[] myArray = myFunction(myNumber);
                for (int i = 0; i < myArray.Length; ++i)
                {
                    Console.WriteLine("InteropTest myArray[{0}] = {1}", i, myArray[i]);
                }
            }
        }
    }
