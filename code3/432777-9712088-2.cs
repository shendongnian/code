    class Program
    {
        static void Main(string[] args)
        {
    
            using (var x = new ArrayCast())
            {
                x.Run();
            } 
            
            using (var x = new ArrayCastList())
            {
                x.Run();
            }
            using (var x = new ArrayCastAsParallel())
            {
                x.Run();
            }
     
            while (Console.Read() != 'q')
            {
                ;    // do nothing...
            }
        }
    }
    public abstract class Experiment : IAmATest, IDisposable
    {
        private Stopwatch _timer;
        protected bool IgnoreAssert { get; set; }
        #region IAmATest Members
        public abstract void Arrange();
        public abstract void Act();
        public abstract void Assert();
        #endregion
        public void Run()
        {
            _timer = Stopwatch.StartNew();
            Arrange();
            _timer.Stop();
            Console.WriteLine(String.Join(":", "Arrange", _timer.ElapsedMilliseconds));
            _timer = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            Act();
            _timer.Stop();
            Console.WriteLine(String.Join(":", "Act", _timer.ElapsedMilliseconds));
            
            if (IgnoreAssert) { return; }
            _timer = Stopwatch.StartNew();
            Assert();
            _timer.Stop();
            Console.WriteLine(String.Join(":", "Assert", _timer.ElapsedMilliseconds));
        }
        public abstract void Dispose();
    }
    public class ArrayCast : Experiment
    {
        private int[] _a;
        double[] _result;
        public override void Arrange()
        {
            IgnoreAssert = true;
            _a = new int[100000];
        }
        public override void Act()
        {
                _result = (from m in _a select (double)m).ToArray();
        }
        public override void Assert() { }
        public override void Dispose() { _a = null; }
    }
    public class ArrayCastAsParallel : Experiment
    {
        private int[] _a;
        double[] _result;
        public override void Arrange()
        {
            IgnoreAssert = true;
            _a = new int[100000];
        }
        public override void Act()
        {
            _result = (from m in _a.AsParallel() select (double)m).ToArray();
        }
        public override void Assert() { }
        public override void Dispose() { _a = null; }
    }
    public class ArrayCastList : Experiment
    {
        private int[] _a;
        double[] _result;
        public override void Arrange()
        {
            IgnoreAssert = true;
            _a = new int[100000];
        }
        public override void Act()
        {
            var x = new List<double>(_a.Select(p => (double)p));
        }
        public override void Assert() { }
        public override void Dispose() { _a = null; }
    }
