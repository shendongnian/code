    using BenchmarkDotNet.Running;
    using BenchmarkDotNet.Attributes;
    class Program
    {
        static void Main()
        {
            var summary = BenchmarkRunner.Run<YourBenchmarks>();
        }
    }
   
    public class YourBenchmarks
    {
        [Benchmark]
        public object HideDataUsingAlgorithm()
        {
            return Namespace.hideDataUsingAlgorithm(); // call the code you want to benchmark here
        }
    }
