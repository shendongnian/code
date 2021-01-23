    public class MyService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public static int Add(int value1, int value2)
        {
            return Execute(() =>
            {
                var calculator = new Calculator();
                return calculator.Add(value1, value2);
            });
        }
        private static Logger logger =
            LogManager.GetLogger(typeof(MyService).Name);
        private static System.Threading.SemaphoreSlim ss =
            new System.Threading.SemaphoreSlim(1, 1);
        private void Execute(Action method)
        {
            ss.Wait();
            try { method.Invoke(); }
            catch (Exception ex)
            {
                logger.FatalException(method.Method + " failed", ex); throw; 
            }
            finally { ss.Release(); }
        }
        private T Execute<T>(Func<T> method)
        {
            ss.Wait();
            try { return method.Invoke(); }
            catch (Exception ex)
            {
                logger.FatalException(method.Method + " failed", ex); throw; 
            }
            finally
            {
                ss.Release();
            }
        }
    }
