        public class LogImpl : LoggerWrapperImpl, ILog
        {
            ...
            public LogImpl(ILogger logger) : base(logger)
            {
                ...
            }
            /// <summary>
            /// The fully qualified name of this declaring type not the type of any subclass.
            /// </summary>
            private readonly static Type ThisDeclaringType = typeof(LogImpl);
            
            virtual public void Error(object message, Exception exception)
            {
                Logger.Log(ThisDeclaringType, m_levelError, message, exception);
            }
            
            ...
        }
