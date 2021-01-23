    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SOTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program program = new Program();
    
                EventDtoA a = new EventDtoA() { AProperty = 0, BaseProperty = -1 };
                EventDtoB b = new EventDtoB() { BProperty = 1, BaseProperty = -1 };
                EventDtoC c = new EventDtoC() { CProperty = 2, BaseProperty = -1 };
    
                var aBytes = program.SerializeMessage(a);
                var bBytes = program.SerializeMessage(b);
                var cBytes = program.SerializeMessage(c);
    
                var aString = System.Text.Encoding.UTF8.GetString(aBytes);
    
                EventDto aNew = program.DeserializeMessage(aBytes);
                EventDto bNew = program.DeserializeMessage(bBytes);
                EventDto cNew = program.DeserializeMessage(cBytes);
    
                aNew.Process();
                bNew.Process();
                cNew.Process();
    
                Console.ReadKey();
            }
    
            private byte[] SerializeMessage(EventDto eventDto)
            {
                var stream = new MemoryStream();
                var serializer = new DataContractJsonSerializer(typeof(EventDto));
                serializer.WriteObject(stream, eventDto);
                var tempBytes = new Byte[stream.Length];
                Array.Copy(stream.GetBuffer(), tempBytes, stream.Length);
                return tempBytes;
            }
    
            private EventDto DeserializeMessage(byte[] body)
            {
                var stream = new MemoryStream(body);
                var serializer = new DataContractJsonSerializer(typeof(EventDto));
    
                var eventDto = (EventDto)serializer.ReadObject(stream);
    
                return eventDto;
            }
    
            public void ProcessMessage(byte[] serializedEvent)
            {
                //Deserialize
                var eventDto = DeserializeMessage(serializedEvent);
    
                //Process
                eventDto.Process();
            }
    
    
        }
    
        [KnownType(typeof(EventDtoA))]
        [KnownType(typeof(EventDtoB))]
        [KnownType(typeof(EventDtoC))]
        public class EventDto
        {
            public virtual void Process() 
            {
                Console.WriteLine("From EventDto Base Class");
            }
    
            public int BaseProperty { get; set; }
        }
    
        public class EventDtoA : EventDto
        {
            public override void Process()
            {
                Console.WriteLine("From EventDto A");
            }
    
            public int AProperty { get; set; }
        }
    
        public class EventDtoB : EventDto
        {
            public override void Process()
            {
                Console.WriteLine("From EventDto B");
            }
    
            public int BProperty { get; set; }
        }
    
        public class EventDtoC : EventDto
        {
            public override void Process()
            {
                Console.WriteLine("From EventDto C");
            }
    
            public int CProperty { get; set; }
        }
    }
