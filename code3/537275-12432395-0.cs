    using System;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;
    
    namespace ConsoleApplication1
    {
        public enum ConnectionStatus
        {
            Online,
            Offline,
            System // System checks connectivity
        }
    
        public static class Connectivity
        {
            private static ConnectionStatus ConnectionStatus = ConnectionStatus.Offline;
    
            public static void ForceConnectionStatus(ConnectionStatus connectionStatus)
            {
                ConnectionStatus = connectionStatus;
            }
    
            public static bool IsConnected()
            {
                switch (ConnectionStatus)
                {
                    case ConnectionStatus.Online:
                        return true;
                    case ConnectionStatus.Offline:
                        return false;
                    case ConnectionStatus.System:
                        return CheckConnection();
                }
                return false;
            }
    
            private static bool CheckConnection()
            {
                return true;
            }
        }
    
        public class Unity
        {
            public static IUnityContainer Container;
    
            public static void Initialize()
            {
                Container = new UnityContainer();
    
                Container.AddNewExtension<Interception>();
                Container.RegisterType<ILogger, OnlineLogger>();
                Container.Configure<Interception>().SetInterceptorFor<ILogger>(new InterfaceInterceptor());
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Unity.Initialize();
    
                var r = new Router<ILogger, OnlineLogger, OnlineLogger>();
    
                Connectivity.ForceConnectionStatus(ConnectionStatus.Offline);
                
                Console.WriteLine("Calling Online, will attend offline: ");
    
                r.Logger.Write("Used offline.");
    
                Connectivity.ForceConnectionStatus(ConnectionStatus.Online);
    
                Console.WriteLine("Calling Online, will attend online: ");
    
                r.Logger.Write("Used Online. Clap Clap Clap.");
    
                Console.ReadKey();
            }
        }
    
        public class Router<TContract, TOnline, TOffline>
            where TOnline : TContract
            where TOffline : TContract
        {
            public TContract Logger;
    
            public Router()
            {
                Logger = Unity.Container.Resolve<TContract>();
            }
        }
    
        public interface IOnline
        {
            IOffline Offline { get; set; }
        }
    
        public interface IOffline
        {
        }
    
        public interface ILogger
        {
            [Test()]
            void Write(string message);
        }
    
        public class OnlineLogger : ILogger, IOnline
        {
            public IOffline Offline { get; set; }
    
            public OnlineLogger()
            {
                this.Offline = new OfflineLogger();
            }
    
            public void Write(string message)
            {
                Console.WriteLine("Online Logger: " + message);
            }
        }
    
        public class OfflineLogger : ILogger, IOffline
        {
            public IOnline Online { get; set; }
    
            public void Write(string message)
            {
                Console.WriteLine("Offline Logger: " + message);
            }
        }
    
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public class TestAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new TestHandler();
            }
        }
    
        public class TestHandler : ICallHandler
        {
            public int Order { get; set; }
    
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                Console.WriteLine("It's been intercepted.");
    
                if (!Connectivity.IsConnected() && input.Target is IOnline)
                {
                    Console.WriteLine("It's been canceled.");
    
                    var offline = ((input.Target as IOnline).Offline);
    
                    if (offline == null)
                        throw new Exception("Online class did not initialized Offline Dispatcher.");
    
                    var offlineResult = input.MethodBase.Invoke(offline, this.GetObjects(input.Inputs));
    
                    return input.CreateMethodReturn(offlineResult, this.GetObjects(input.Inputs));
                }
    
                return getNext()(input, getNext);
            }
    
            private object[] GetObjects(IParameterCollection parameterCollection)
            {
                var parameters = new object[parameterCollection.Count];
    
                int i = 0;
                foreach (var parameter in parameterCollection)
                {
                    parameters[i] = parameter;
                    i++;
                }
                return parameters;
            }
        }
    }
