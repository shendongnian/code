    namespace StackOverflowExample.Moq
    {
        public interface ILogCreator
        {
            ILog GetTypeLogger<T>() where T : class;
        }
    
        public class LogCreator : ILogCreator
        {
            private static readonly IDictionary<Type, ILog> loggers = new Dictionary<Type, ILog>();
            private static readonly object lockObject;
    
            public ILog GetTypeLogger<T>() where T : class
            {
                var loggerType = typeof (T);
                if (loggers.ContainsKey(loggerType))
                {
                    return loggers[typeof (T)];
                }
    
                lock (lockObject)
                {
                    if (loggers.ContainsKey(loggerType))
                    {
                        return loggers[typeof(T)];
                    }
                    var logger = LogManager.GetLogger(loggerType);
                    loggers[loggerType] = logger;
                    return logger;
                }
            }
        }
    
        public class ClassWithLogger
        {
            private readonly ILog logger;
            public ClassWithLogger(ILogCreator logCreator)
            {
                logger = logCreator.GetTypeLogger<ClassWithLogger>();
            }
    
            public void DoSomething()
            {
                logger.Debug("called");
            }
        }
    
        [TestFixture]
        public class Log4Net
        {
            [Test]
            public void DoSomething_should_write_in_debug_logger()
            {
                //arrange
                var logger = new Mock<ILog>();
                var loggerCreator = Mock.Of<ILogCreator>(
                    c =>
                    c.GetTypeLogger<ClassWithLogger>() == logger.Object);
    
                var sut = new ClassWithLogger(loggerCreator);
    
                //act
                sut.DoSomething();
    
                //assert
                logger.Verify(l=>l.Debug("called"), Times.Once());
            }
        }
    } 
