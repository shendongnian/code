    using System;
    using System.Diagnostics;
    using System.Threading;
    abstract class Experiment
    {
        public abstract double GetValue();
    }
    class Example1 : Experiment
    {
        private readonly object _sync = new object();
        private double _value = 3;
        public override double GetValue()
        {
            lock (_sync)
            {
                return _value;
            }
        }
    }
    class Example2 : Experiment
    {
        private readonly object _sync = new object();
        private double _value = 3;
        public override double GetValue()
        {
            lock (_sync)
            {
                return _value;
            }
        }
    }
    
    class Example3 : Experiment
    {
        private readonly object _sync = new object();
        private double _value = 3;
        public override double GetValue()
        {
            double result = 0;
            lock (_sync)
            {
                result = _value;
            }
            return result;
        }
    }
    
    class CompareExchange : Experiment
    {
        private double _value = 3;
        public override double GetValue()
        {
            return Interlocked.CompareExchange(ref _value, 0, 0);
        }
    }
    class ReadUnsafe : Experiment
    {
        private long _value = DoubleToLong(3);
        static unsafe long DoubleToLong(double val)
        {   // I'm mainly including this for the field initializer
            // in real use this would be manually inlined
            return *(long*)(&val);
        }
        public override unsafe double GetValue()
        {
            long val = Interlocked.Read(ref _value);
            return *(double*)(&val);
        }
    }
    class UntypedBox : Experiment
    {
        // references are always atomic
        private object _value = 3.0;
        public override double GetValue()
        {
            return (double)_value;
        }
    }
    class TypedBox : Experiment
    {
        private sealed class Box
        {
            public readonly double Value;
            public Box(double value) { Value = value; }
    
        }
        private Box _value = new Box(3);
        public override unsafe double GetValue()
        {
            return _value.Value;
        }
    }
    static class Program
    {
        static void Main()
        {
            // once for JIT
            RunExperiments(1);
            // three times for real
            RunExperiments(5000000);
            RunExperiments(5000000);
            RunExperiments(5000000);
        }
        static void RunExperiments(int loop)
        {
            Console.WriteLine("x{0}", loop);
            RunExperiment(new Example1(), loop);
            RunExperiment(new Example2(), loop);
            RunExperiment(new Example3(), loop);
            RunExperiment(new CompareExchange(), loop);
            RunExperiment(new ReadUnsafe(), loop);
            RunExperiment(new UntypedBox(), loop);
            RunExperiment(new TypedBox(), loop);
            Console.WriteLine();
        }
        static void RunExperiment(Experiment test, int loop)
        {
            // avoid any GC interruptions
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
    
            double val = 0;
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < loop; i++)
                val = test.GetValue();
            watch.Stop();
            if (val != 3.0) Console.WriteLine("FAIL!");
            Console.WriteLine("{0}\t{1}ms", test.GetType().Name,
                watch.ElapsedMilliseconds);
    
        }
    
    }
