    using System;
    using System.Diagnostics;
    using System.Threading;
    
    abstract class Experiment
    {
        public abstract double GetValue();
        public abstract void SetValue(double value);
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
    
        public override void SetValue(double value)
        {
            lock (_sync)
            {
                _value = value;
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
    
        public override void SetValue(double value)
        {
            lock (_sync)
            {
                _value = value;
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
    
        public override void SetValue(double value)
        {
            lock (_sync)
            {
                _value = value;
            }
        }
    }
    
    class CompareExchange : Experiment
    {
        private double _value = 3;
        public override double GetValue()
        {
            return Interlocked.CompareExchange(ref _value, 0, 0);
        }
    
        public override void SetValue(double value)
        {
            double current = Thread.VolatileRead(ref _value);
            double previous;
            do
            {
                previous = current;
                current = Interlocked.CompareExchange(ref _value, value, previous);
            } while (current != previous);
        }
    }
    class ReadUnsafe : Experiment
    {
        private long _value = DoubleToInt64(3);
        static unsafe long DoubleToInt64(double val)
        {   // I'm mainly including this for the field initializer
            // in real use this would be manually inlined
            return *(long*)(&val);
        }
        public override unsafe double GetValue()
        {
            long val = Interlocked.Read(ref _value);
            return *(double*)(&val);
        }
    
        public override void SetValue(double value)
        {
            long intValue = DoubleToInt64(value);
            long current = Interlocked.Read(ref _value);
            long previous;
            do
            {
                previous = current;
                current = Interlocked.CompareExchange(ref _value, intValue, previous);
            } while (current != previous);
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
    
        public override void SetValue(double value)
        {
            object valueObject = value;
            object current = Thread.VolatileRead(ref _value);
            object previous;
            do
            {
                previous = current;
                current = Interlocked.CompareExchange(ref _value, valueObject, previous);
            } while (current != previous);
        }
    }
    class TypedBox : Experiment
    {
        private sealed class Box
        {
            public readonly double Value;
            public Box(double value) { Value = value; }
    
        }
        // references are always atomic
        private Box _value = new Box(3);
        public override double GetValue()
        {
            return _value.Value;
        }
    
        public override void SetValue(double value)
        {
            Box boxValue = new Box(value);
            Box current = _value;
            Box previous;
            do
            {
                previous = current;
                current = Interlocked.CompareExchange(ref _value, boxValue, previous);
            } while (current != previous);
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
    
            // +1 for our own
            //
            int threads = Environment.ProcessorCount + 1;
            
            // Since we use threads, divide the original workload
            //
            int workerLoop = loop / Environment.ProcessorCount;
    
            ManualResetEvent done = new ManualResetEvent(false);
    
            var watch = Stopwatch.StartNew();
    
            for (int t = 0; t < Environment.ProcessorCount; ++t)
            {
                ThreadPool.QueueUserWorkItem((state) =>
                    {
                        try
                        {
                            double val = 0;
    
                            // Two loops to avoid comparison for % in the inner loop
                            //
                            int writeRatio = 1000;
                            int writes = Math.Max(workerLoop / writeRatio, 1);
                            int reads = loop / writes;
                            for (int j = 0; j < writes; ++j)
                            {
                                test.SetValue(j);
                                for (int i = 0; i < reads; i++)
                                {
                                    val = test.GetValue();
                                }
                            }
                        }
                        finally
                        {
                            if (0 == Interlocked.Decrement(ref threads))
                            {
                                done.Set();
                            }
                        }
                    });
            }
            if (0 != Interlocked.Decrement(ref threads))
            {
                done.WaitOne();
            }
            watch.Stop();
            Console.WriteLine("{0}\t{1}ms", test.GetType().Name,
                watch.ElapsedMilliseconds);
    
        }
    
    }
