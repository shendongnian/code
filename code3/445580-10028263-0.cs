    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplicationPlayground
    {
      class Program
      {
        static void Main(string[] args)
        {
          while (true)
          {
            Console.WriteLine("Available Physical Memory (MiB) " + PerformanceInfo.GetPhysicalAvailableMemoryInMiB().ToString());
            Console.ReadLine();
          }
        }
      }
    
      public static class PerformanceInfo
      {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
          public int Size;
          public IntPtr CommitTotal;
          public IntPtr CommitLimit;
          public IntPtr CommitPeak;
          public IntPtr PhysicalTotal;
          public IntPtr PhysicalAvailable;
          public IntPtr SystemCache;
          public IntPtr KernelTotal;
          public IntPtr KernelPaged;
          public IntPtr KernelNonPaged;
          public IntPtr PageSize;
          public int HandlesCount;
          public int ProcessCount;
          public int ThreadCount;
        }
    
        public static int GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
              return Convert.ToInt32((pi.PhysicalAvailable.ToInt32() * pi.PageSize.ToInt32() / 1048576));
            }
            else
            {
              return -1;
            }
    
        }
    
      }
    }
