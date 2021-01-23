    using System;
    using System.Diagnostics;
    namespace CpuUsage
    {
      class Program
      {
        static void Main(string[] args)
        {
          PerformanceCounter cpuCounter = new PerformanceCounter();
          cpuCounter.CategoryName = "Processor";
          cpuCounter.CounterName = "% Processor Time";
          cpuCounter.InstanceName = "_Total";
          PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
          var unused = cpuCounter.NextValue(); // first call will always return 0
          System.Threading.Thread.Sleep(1000); // wait a second, then try again
          Console.WriteLine("Cpu usage: " + cpuCounter.NextValue() + "%");
          Console.WriteLine("Free ram : " + ramCounter.NextValue() + "MB");
          Console.ReadKey();
        }
      }
    }
