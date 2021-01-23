    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Reactive.Threading;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    class Program
    {
        public static void Main()
        {
            var packets = getMyPacket().ContinueWith((a) =>
            {
                Packet packet = null;
                if (a.Exception != null && a.Exception.InnerException.GetType() == typeof(TimeoutException))
                {
                    packet = new ErrorPacket(Error.TIMEOUT);
                }
                else
                {
                    packet = a.Result;
                }
                return packet;
            });
            Console.ReadLine();
            Console.WriteLine(packets.Result.GetType());
        }
        static async Task<Packet> getMyPacket()
        {
            var list = new List<Packet>();
            list.Add(new Packet(FrameType.CMD_ID_0));
            IObservable<Packet> packets = list.ToObservable();
            var aw = await packets
                     .Where(x => x.FrameType == FrameType.CMD_ID_0)
                     .FirstAsync()
                     //.Timeout(TimeSpan.FromSeconds(0))
                     .GetAwaiter();
            return aw;
        }
        class Packet
        {
            public FrameType FrameType { get; set; }
            public Packet() 
            {
            }
            public Packet(FrameType frameType)
            {
                FrameType = frameType;
            }
        }
        class ErrorPacket : Packet
        {
            public ErrorPacket(Error error)
            {
            }
        }
        enum FrameType
        {
            CMD_ID_0,
            CMD_ID_1
        }
        enum Error
        {
            TIMEOUT
        }
    }
