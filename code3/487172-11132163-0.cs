    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.Timers;
    using System.ServiceModel.Description;
    
    namespace WcfConsoleApplication
    {
        [ServiceContract]
        public interface ITimerCallbackTarget
        {
            [OperationContract(IsOneWay = true)]
            void OnTimeElapsed(int someInfo);
        } 
    
        [ServiceContract]
        public interface ITimerService
        {
            [OperationContract(IsOneWay = true)]
            void Subscribe(string address);
        }
    
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                         ConcurrencyMode = ConcurrencyMode.Single)]
        public class TimerService : ITimerService
        {
            private readonly Timer _timer = new Timer(2000);
            private ChannelFactory<ITimerCallbackTarget> _channelFac;
            private int _dataToSend = 99;
    
            public void Subscribe(string address)
            {
                // note: You can also load a configured endpoint by name from app.config here,
                //       and still change the address at runtime in code.
                _channelFac = new ChannelFactory<ITimerCallbackTarget>(new BasicHttpBinding(), address);
    
                _timer.Elapsed += (p1, p2) =>
                {
                    ITimerCallbackTarget callback = _channelFac.CreateChannel();
                    callback.OnTimeElapsed(_dataToSend++);
    
                    ((ICommunicationObject)callback).Close();
    
                    // By not keeping the channel open any longer than needed to make a single call
                    // there's no risk of timeouts, disposed objects, etc.
                    // Caching the channel factory is not required, but gives a measurable performance gain.
                };
                _timer.Start();
            }
        }
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                         ConcurrencyMode = ConcurrencyMode.Single)]
        public class TimerClient : ITimerCallbackTarget
        {
            public void OnTimeElapsed(int someInfo)
            {
                Console.WriteLine("Got Info: " + someInfo);
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                ServiceHost hostTimerService = new ServiceHost(typeof(TimerService), new Uri("http://localhost:8080/TimerService"));
                ServiceHost hostTimerClient = new ServiceHost(typeof(TimerClient), new Uri("http://localhost:8080/TimerClient"));
                ChannelFactory<ITimerService> proxyFactory = null;
    
                try
                {
                    // start the services
                    hostTimerService.Open();
                    hostTimerClient.Open();
    
                    // subscribe to ITimerService
                    proxyFactory = new ChannelFactory<ITimerService>(new BasicHttpBinding(), "http://localhost:8080/TimerService");
                    ITimerService timerService = proxyFactory.CreateChannel();
                    timerService.Subscribe("http://localhost:8080/TimerClient");
                    ((ICommunicationObject)timerService).Close();
    
                    // wait for call backs...
                    Console.WriteLine("Wait for Elapsed updates. Press enter to exit.");
                    Console.ReadLine();
                }
                finally
                {
                    hostTimerService.Close();
                    hostTimerClient.Close();
                    proxyFactory.Close();
                }
            }
        }
    }
