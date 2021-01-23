    static void Main(string[] args)
        {
            const string Address1 = "A:2.1.1";
            const string Address2 = "A:2.1.2";
            var comparer = new EventComparer();
            var eventMessageA1 = new EventMessage { NetworkAddress = Address1, EventCode = 1, Attribute = 4 };
            var eventMessageB1 = new EventMessage { NetworkAddress = Address2, EventCode = 1, Attribute = 5 };
            var eventMessageA2 = new EventMessage { NetworkAddress = Address1, EventCode = 1, Attribute = 5 };
            var list = new[] { eventMessageA1, eventMessageA1, eventMessageB1, eventMessageA2, eventMessageA1, eventMessageA1 };
            var queue = new BlockingCollection<EventMessage>();
            Observable.Interval(TimeSpan.FromSeconds(2)).Subscribe
                (
                    l => list.ToList().ForEach(m =>
                    {
                        Console.WriteLine("Producing {0} on thread {1}", m, Thread.CurrentThread.ManagedThreadId);
                        queue.Add(m);
                    })
                );
            // subscribing
            queue.GetConsumingEnumerable()
                .ToObservable()
                 .Buffer(TimeSpan.FromSeconds(5))
                 .Subscribe(e =>
                     {
                         Console.WriteLine("Queue contains {0} items", queue.Count);
                         e.Distinct(comparer).ToList().ForEach(m =>
                      Console.WriteLine("{0} - Consuming: {1} (queue contains {2} items)", DateTime.UtcNow, m, queue.Count));
                     }
                 );
            Console.WriteLine("Type enter to exit");
            Console.ReadLine();
        }
        public class EventComparer : IEqualityComparer<EventMessage>
        {
            public bool Equals(EventMessage x, EventMessage y)
            {
                var result = x.NetworkAddress == y.NetworkAddress && x.EventCode == y.EventCode && x.Attribute == y.Attribute;
                return result;
            }
            public int GetHashCode(EventMessage obj)
            {
                var s = string.Concat(obj.NetworkAddress + "_" + obj.EventCode + "_" + obj.Attribute);
                return s.GetHashCode();
            }
        }
        public class EventMessage
        {
            public string NetworkAddress { get; set; }
            public byte EventCode { get; set; }
            public byte Attribute { get; set; }
            public override string ToString()
            {
                const string Format = "{0} ({1}, {2})";
                var s = string.Format(Format, this.NetworkAddress, this.EventCode, this.Attribute);
                return s;
            }
        }
