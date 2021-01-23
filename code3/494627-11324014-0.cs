    public class SynchronizedPacketQueue
       {
          [DataMember]
          public List<Packet> packetsQ;
          private object mylock = new object();
          
          public SynchronizedPacketQueue()
          {
            packetsQ = new List<Packet>();
          }
    
        public int Count
        {
            get { return packetsQ.Count; }
            private set{}
        }
    
    
        public Packet Dequeue()
        {
            lock (mylock)
            {
                if (packetsQ.Count == 0)
                {
                    Monitor.Wait(packetsQ);
    
                }
                Packet packet = packetsQ[0];
                packetsQ.RemoveAt(0);
                return packet;
            }
        }
    
        public void  Enqueue(Packet packet)
        {
            lock (mylock)
            {
                packetsQ.Add(packet);
                Monitor.Pulse(packetsQ);
            }
        }
    }
