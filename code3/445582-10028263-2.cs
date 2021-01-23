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
            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;
            Console.WriteLine("Available Physical Memory (MiB) " + phav.ToString());
            Console.WriteLine("Total Memory (MiB) " + tot.ToString());
            Console.WriteLine("Free (%) " + percentFree.ToString());
            Console.WriteLine("Occupied (%) " + percentOccupied.ToString());
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
    
        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
              return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
              return -1;
            }
    
        }
    
        public static Int64 GetTotalMemoryInMiB()
        {
          PerformanceInformation pi = new PerformanceInformation();
          if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
          {
            return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
          }
          else
          {
            return -1;
          }
    
        }
      }
    }
