    namespace FixedSizeBuffers
    {
        internal unsafe struct MyBuffer
        {
            public fixed int fixedBuffer[128];
        }
    
        internal unsafe class MyClass
        {
            public MyBuffer myBuffer = default(MyBuffer);
        }
    
        internal class Program
        {
            static void Main()
            {
                MyClass myClass = new MyClass();
    
                unsafe
                {
                    // Pin the buffer to a fixed location in memory.
                    fixed (int* intPtr = myClass.myBuffer.fixedBuffer)
                    {
                        *intPtr = someIntValue;
                    }
                }
            }
        }
    }
