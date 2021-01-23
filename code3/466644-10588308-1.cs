        [DataContract]
        public class Message
        {
            [DataMember]
            public DateTime? Date { get; set; }
            [DataMember]
            public string AString { get; set; }
            [DataMember]
            public Dictionary<string, string> Attributes { get; set; }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Description { get; set; }
        }
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Message));
            Message message = null;
            using (MemoryStream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                // Deserialize
                message = (Message)jsonSerializer.ReadObject(jsonStream);
                // Go to the beginning and discard the current stream contents.
                jsonStream.Seek(0, SeekOrigin.Begin);
                jsonStream.SetLength(0);
                // Serialize
                jsonSerializer.WriteObject(jsonStream, message);
                jsonString = Encoding.UTF8.GetString(jsonStream.ToArray());
            }
