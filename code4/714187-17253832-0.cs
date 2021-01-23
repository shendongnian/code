    class MyHeartBeatMonitor
    {
        public event EventHandler<AbnormalHeartRateSimulation> Abnormalheartbeats;
    
        public void NotifyFamilyDoctor()
        {
            EventHandler<AbnormalHeartRateSimulation> handler 
                                                       = Abnormalheartbeats;
            if (handler != null)
            {
                AbnormalHeartRateSimulation simulatedRates =
                                            new AbnormalHeartRateSimulation();
                simulatedRates.heartRate = 140;
                handler(this, simulatedRates);
            }
  
      }
    }
    public class AbnormalHeartRateSimulation : EventArgs
        {
            public int heartRate { get; set; }
        }
    class FamilyDoctor
      {
       public void EventHandler(
                              object sender,AbnormalHeartRateSimulation args)
       {
          Console.WriteLine("Your Patient's HearRate is " + args.heartRate);
        }
      
    
        }
    class Program
        {
         static void Main(string[] args)
         {
           MyHeartBeatMonitor monitor = new MyHeartBeatMonitor();
           FamilyDoctor doctor = new FamilyDoctor();
           monitor.Abnormalheartbeats += doctor.EventHandler;
           monitor.NotifyFamilyDoctor();
           Console.ReadKey(true);
          }
    }
