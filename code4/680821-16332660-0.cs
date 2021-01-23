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
          Console.WriteLine("Cpu usage: " + cpuCounter.NextValue() + "%");
          Console.WriteLine("Free ram : " + ramCounter.NextValue() + "MB");
          Console.ReadKey();
        }
      }
    }
