        public class StackOverflow_10531128
        {
            const string MTOM = @"MIME-Version: 1.0
    Content-Type: Multipart/Related;boundary=DeltaSync91ABCB4AF5D24B8F988B77ED7A19733D?MTOM;
        type=""application/xop+xml"";
        start=""<DeltaSyncMTOMFetchResponse@mail.services.live.com>"";
    
    --DeltaSync91ABCB4AF5D24B8F988B77ED7A19733D?MTOM
    content-transfer-encoding: binary
    Content-Type: application/xop+xml; charset=utf-8; type=""application/xop+xml""
    content-id: <DeltaSyncMTOMFetchResponse@mail.services.live.com>
    
    <ItemOperations xmlns:xop=""http://www.w3.org/2004/08/xop/include"" xmlns:B=""HMMAIL:"" xmlns:D=""HMSYNC:"" xmlns=""ItemOperations:"">
        <Status>1</Status>
        <Responses>
            <Fetch>
                <ServerId>E631966A-9439-11E1-8E7B-00215AD9A7B8</ServerId>
                <Status>1</Status>
                <Message><xop:Include href=""cid:1.634715231374437235@example.org"" /></Message>
            </Fetch>
        </Responses>
    </ItemOperations>
    --DeltaSync91ABCB4AF5D24B8F988B77ED7A19733D?MTOM
    content-transfer-encoding: binary
    Content-Type: application/octet-stream
    content-id: <1.634715231374437235@example.org>
    
    this is a binary content; it could be anything but for simplicity I'm using text
    --DeltaSync91ABCB4AF5D24B8F988B77ED7A19733D?MTOM--";
    
            [DataContract(Name = "ItemOperations", Namespace = "ItemOperations:")]
            public class ItemOperations
            {
                [DataMember(Order = 1)]
                public int Status { get; set; }
                [DataMember(Order = 2)]
                public Responses Responses { get; set; }
            }
    
            [CollectionDataContract(Name = "Responses", Namespace = "ItemOperations:", ItemName = "Fetch")]
            public class Responses : List<Fetch>
            {
            }
    
            [DataContract(Name = "Fetch", Namespace = "ItemOperations:")]
            public class Fetch
            {
                [DataMember(Order = 1)]
                public Guid ServerId { get; set; }
                [DataMember(Order = 2)]
                public int Status { get; set; }
                [DataMember(Order = 3)]
                public byte[] Message { get; set; }
            }
    
            public static void Test()
            {
                MemoryStream ms;
                ItemOperations obj;
                DataContractSerializer dcs = new DataContractSerializer(typeof(ItemOperations));
    
                string fixedMtom = MTOM.Replace(
                    "Multipart/Related;boundary=DeltaSync91ABCB4AF5D24B8F988B77ED7A19733D?MTOM;",
                    "Multipart/Related;boundary=\"DeltaSync91ABCB4AF5D24B8F988B77ED7A19733D?MTOM\";");
                ms = new MemoryStream(Encoding.UTF8.GetBytes(fixedMtom));
                XmlDictionaryReader reader = XmlDictionaryReader.CreateMtomReader(ms, Encoding.UTF8, XmlDictionaryReaderQuotas.Max);
                obj = (ItemOperations)dcs.ReadObject(reader);
                Console.WriteLine(obj.Status);
                Console.WriteLine(obj.Responses.Count);
                foreach (var resp in obj.Responses)
                {
                    Console.WriteLine("  {0}", resp.ServerId);
                    Console.WriteLine("  {0}", resp.Status);
                    Console.WriteLine("  {0}", string.Join(" ", resp.Message.Select(b => string.Format("{0:X2}", (int)b))));
                }
            }
        }
