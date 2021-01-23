    public struct Packet
    {
        public Guid Id;
        public Packet(Guid id)
        {
            Id = id;
        }
    }
    public class Agent
    {
        public Server Server;
        public Proccessor Proccessor;
        public void SendPacket()
        {
            var leadInTime = TimeSpan.FromMilliseconds(100);
            var expectedSend = DateTime.Now + leadInTime;
            var packet = new Packet(Guid.NewGuid());
            Server.RegisterNextPacket(expectedSend);
            //You need a fast way to wake and a send at the specific time
            Thread.Sleep(leadInTime); //Fake it
            Proccessor.Process(packet);
        }
    }
    public class Proccessor
    {
        public Server Server; 
        public void Process(Packet packet)
        {
            Thread.Sleep(1500);
            Server.HandleInput(packet);
        }
    }
    public class Server
    {
        private DateTime _expected;
        public void HandleInput(Packet packet)
        {
            var timeArrival = DateTime.Now;
            var difference = timeArrival - _expected;
            Console.WriteLine("Approximate time from Agent To Server, via Processor: " + difference);
        }
        public void RegisterNextPacket(DateTime expectedDeliveryStart)
        {
            _expected = expectedDeliveryStart;
            Console.WriteLine("Expecting it at: " + _expected);
        }
    }
    internal class Program
    {
        static public void Main()
        {
            var agent = new Agent();
            var server = new Server();
            var processor = new Proccessor();
            agent.Proccessor = processor;
            agent.Server = server;
            processor.Server = server;
            agent.SendPacket();
        }
    }
