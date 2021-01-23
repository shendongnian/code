    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using RGiesecke.DllExport;
    namespace ManagedCSharpDLL
    {
      public static class UnmanagedExports
      {
        private static CallbackProc _callback;
        [DllExport("SetCallback", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void SetCallback(CallbackProc pCallback)
        {
          _callback = pCallback;
          MessageBox.Show("C#: SetCallback Completed");
        }
        [DllExport("TestCallback", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void TestCallback(string passedString)
        {
          string displayValue = passedString;
          string returnValue = String.Empty;
          MessageBox.Show("C#: About to call the Callback. displayValue=" + displayValue + ", returnValue=" + returnValue);
          _callback(displayValue, ref returnValue);
          MessageBox.Show("C#: Back from the Callback. displayValue=" + displayValue + ", returnValue=" + returnValue);
        }
        public delegate void CallbackProc( [MarshalAs(UnmanagedType.BStr)] String PassedValue,  [MarshalAs(UnmanagedType.BStr)] ref String ReturnValue);
      }
    }
