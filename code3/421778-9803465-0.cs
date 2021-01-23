    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            // Set the library path
            const string dllFilePath = 
            "C:\\PathToProject\\TestCallBack\\ConsoleApp\\lib\\TestCallBack.dll";
            // This is the delegate type that we use to marshal
            // a function pointer for C to use. You usually need
            // to specify the calling convention so it matches the
            // convention of your C library. The signature of this
            // delegate must match the signature of the C function
            // pointer we want to use.
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            delegate void FunctionPointer( int nb);
            // This is the function we import from the C library.
            //[DllImport(dllFilePath)]
            [DllImport(dllFilePath, CallingConvention = CallingConvention.Cdecl)]
            public static extern void callCSharpFunction(IntPtr fctPointer);
    
            // This is the placeholder for the function pointer
            // we create using Marshal.GetFunctionPointerForDelegate
            static IntPtr FctPtr;
            // This is the instance of the delegate to which our function
            // pointer will point.
            FunctionPointer MyFunctionPointer;
            
            // This calls the specified delegate using the C library.
            void CallFunctionPointer(FunctionPointer cb)
            {
                // make sure the delegate isn't null
                if (null == cb) throw new ArgumentNullException("cb");
                // set our delegate place holder equal to the specified delegate
                MyFunctionPointer = cb;
                // Get a pointer to the delegate that can be passed to the C lib
                FctPtr = Marshal.GetFunctionPointerForDelegate(MyFunctionPointer);
 
                // call the imported function with that function pointer.
                callCSharpFunction(FctPtr);
            } 
            static void Main(string[] args)
            {
                // This is the instance of the delegate to which our function
                // pointer will point.
                FunctionPointer printInConsoleDelegate;
     
                // Create the delegate object "MyFunctionPointer" that references 
                printInConsoleDelegate = new FunctionPointer(printInConsole);
                // Get a pointer to the delegate that can be passed to the C lib
                IntPtr printInConsolePtr = 
                    Marshal.GetFunctionPointerForDelegate(printInConsoleDelegate);
                Console.WriteLine(
                    "Call C++ which's calling back C# func \"printInConsole\"");
                // Call C++ which calls C#
                callCSharpFunction(printInConsolePtr);
                // Stop the console until user's pressing Enter
                Console.ReadLine();
            }
            public static void printInConsole(int nb) 
            {
                // Write the parameter in the console
                Console.WriteLine("value = " + nb + "; ");
            }
        }
    }
