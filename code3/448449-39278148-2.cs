    public static class Helper
    {
        public static T Time<T>(Func<T> method, ILogger log)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = method();
            stopwatch.Stop();
            log.Info(string.Format("Time Taken For Execution is:{0}", stopwatch.Elapsed.TotalMilliseconds));
            return result;
        }
    }
    
    public class Arithmatic
    {
        private ILogger _log;
        public Arithmatic(ILogger log)//Inject Dependency
        {
            _log = log;
        }
    
        public void Calculate(int a, int b)
        {
            try
            {
                Console.WriteLine(Helper.Time(() => AddNumber(a, b), _log));//Return the result and do execution time logging
                Console.WriteLine(Helper.Time(() => SubtractNumber(a, b), _log));//Return the result and do execution time logging
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex);
            }
        }
    
        private string AddNumber(int a, int b)
        {
            return "Sum is:" + (a + b);
        }
    
        private string SubtractNumber(int a, int b)
        {
            return "Subtraction is:" + (a - b);
        }
    }
    
    public class Log : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    
        public void Error(string message, Exception ex)
        {
            Console.WriteLine("Error Message:" + message, "Stacktrace:" + ex.StackTrace);
        }
    }
    
    public interface ILogger
    {
        void Info(string message);
        void Error(string message, Exception ex);
    }
