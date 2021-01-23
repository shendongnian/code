    using System;
    using log4net;
    namespace StackOverflowExample.Moq
    {
        public class ClassWithLogger
        {
            private static ILog _log;
            //private static readonly ILog log = LogManager.GetLogger(typeof(Prim));
        public ClassWithLogger(ILog log)
        {
            _log = log;
        }
            public void DoSomething(object para = null)
            {
                try
                {
                    if(para != null)
                    {
                        _log.Debug("called");
                    }
                    else
                    {
                        throw new System.ArgumentException("Parameter cannot be null");
                    }
                }
                catch (Exception ex)
                {
                    _log.Fatal("Exception raised!", ex);
                }
            }
        }
    } 
