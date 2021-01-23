    using System;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication2
    {
      internal class Program
      {
       [DllImport("wininet.dll", SetLastError = true)]
       private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);
       private static void Main(string[] args)
       {
        int flags;
        bool isConnected = InternetGetConnectedState(out flags, 0);
        Console.WriteLine(string.Format("Is connected :{0} Flags:{1}", isConnected, flags));
       }
      }
    }
