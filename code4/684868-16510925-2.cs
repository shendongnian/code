    using System;
    using System.Net.Security;
    using System.ServiceModel;
    using System.Threading;
    
    namespace WcfService1
    {
        [ServiceContract(SessionMode = SessionMode.Required,
            CallbackContract = typeof (IStreamCallback),
            ProtectionLevel = ProtectionLevel.None)]
        public interface IService1
        {
            [OperationContract]
            void GetData(int value);
    
            [OperationContract]
            void Stop();
        }
    
        public interface IStreamCallback
        {
            [OperationContract(IsOneWay = true)]
            void StreamSignalData(int[] result);
        }
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
        [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
        public class Service1 : IService1
        {
            private Timer _timer;
    
            private readonly IStreamCallback _callback =
                OperationContext.Current.GetCallbackChannel<IStreamCallback>();
    
            public void GetData(int value)
            {
                _timer = new Timer(StreamData, null, 0, 500);
            }
    
            public void Stop()
            {
                _timer.Dispose();
            }
    
            private void StreamData(object state)
            {
                int[] randomNumbers = new int[50];
                Random random = new Random();
                for (int i = 0; i < 50; i++)
                {
                    randomNumbers[i] = random.Next(100);
                }
                _callback.StreamSignalData(randomNumbers);
            }
        }
    }
