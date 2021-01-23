    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    
    using ProtoBuf;
    namespace ProtobufNetTest2 {
        [DataContract(Name = "Pet", Namespace = "http://www.example.com")]
        public class Pet  {
            [DataMember(Name = "Name")]
            public string Name { get; set; }
        }
    
        [ProtoContract]
        public class DogMessage {
            [ProtoMember(1)]
            public Pet Dog { get; set; }
        }
        
        class Program {
            static void Main(string[] args) {
                var dog = new Pet() {
                    Name = "The Dog",
                };
    
                var dogMessage = new DogMessage() {
                    Dog = dog,
                };
    
                using (var stream = new MemoryStream()) {
                    Serializer.Serialize(stream, dogMessage);
                }
            }
        }
    }
