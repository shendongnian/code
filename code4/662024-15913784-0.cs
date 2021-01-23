     class Program
    {
        [DataContract( Namespace = "http://client/schema/framework/header/standardheaderresponse" )]
        public class StandardHeaderResponse
        {
            [DataMember( Order = 1 )]
            public FromHeaderResponse From { get; set; }
            [DataMember( Order = 2 )]
            public DateTime Timestamp { get; set; }
            [DataMember( Order = 3 )]
            public Guid CorrelationID { get; set; }
        }
        [DataContract( Namespace = "http://client/schema/framework/common/systemidentifier" )]
        public class FromHeaderResponse
        {
            [DataMember( Order = 1 )]
            public string Identifier { get; set; }
            [DataMember( Order = 2 )]
            public string Name { get; set; }
            [DataMember( Order = 3 )]
            public int Version { get; set; }
        }
        static void Main( string[] args )
        {
            Message message = Message.CreateMessage( MessageVersion.Default, "http://client/service.buildingloc.event.BuildingEvent.SendEvent", "Message body" );
            var header = new StandardHeaderResponse()
            {
                CorrelationID = Guid.NewGuid(),
                Timestamp = DateTime.Now,
                From = new FromHeaderResponse()
                {
                    Identifier = "BUS",
                    Name = "BuildingEvent",
                    Version = 1
                }
            };
            message.Headers.Add( MessageHeader.CreateHeader( "StandardHeaderResponse", "http://client/schema/framework/header/standardheaderresponse", header ) );
            message.Headers.Action = @"http://client/service.buildingloc.event.BuildingEvent.SendEvent";
            message.Headers.To = new Uri( @"http://www.w3.org/2005/08/addressing/anonymous" );
            message.Headers.MessageId = new System.Xml.UniqueId( Guid.NewGuid() );
            message.Headers.RelatesTo = new System.Xml.UniqueId( Guid.NewGuid() );
            Console.WriteLine( message.ToString() );
            Console.WriteLine( "Press any key to exit..." );
            Console.ReadKey();
        }
    }
