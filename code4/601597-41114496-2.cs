    public class Logging : IAspect
    {
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            yield return Advice.Basic.After.Throwing((instance, arguments, exception) => 
            {
                Logger.Log(method, arguments, exception);
            });
        }
    }
