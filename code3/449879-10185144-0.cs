    class Program
    {
        static void Main(string[] args)
        {
            TaskProcessor tp = new TaskProcessor();
                        
            Thread t1 = new Thread(new ParameterizedThreadStart(tp.SubmitRequest));
            t1.Start(1);
            Thread t2 = new Thread(new ParameterizedThreadStart(tp.SubmitRequest));
            t2.Start(2);
            Thread t3 = new Thread(new ParameterizedThreadStart(tp.SubmitRequest));
            t3.Start(3);         
        }
    }
    class TaskProcessor
    {
        private AutoResetEvent _Ticket;
        public TaskProcessor()
        {
            _Continue = new AutoResetEvent(false);
        }
        public void SubmitRequest(object i)
        {
            TicketingQueue dt = new TicketingQueue();
            Console.WriteLine("Grab ticket for customer {0}", (int)i);
            dt.GrabTicket(_Ticket);
            _Continue.WaitOne();
            Console.WriteLine("Customer {0}'s turn", (int)i);
        }
    }
    public class TicketingQueue
    {
        private static BlockingCollection<AutoResetEvent> tickets = new BlockingCollection<AutoResetEvent>();
        static TicketingQueue()
        {
            var thread = new Thread(
              () =>
              {
                  while (true)
                  {                      
                      AutoResetEvent e = tickets.Take();
                      e.Set();
                      Thread.Sleep(1000);
                  }
              });
            thread.Start();
        }
        public void GrabTicket(AutoResetEvent e)
        {
            tickets.Add(e);
        }
    }
