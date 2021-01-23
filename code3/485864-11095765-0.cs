    public class StackOverflow_11092274
    {
        const string XML = @"<?xml version=""1.0"" encoding=""utf-8""?> 
    <Data xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/XYZ""> 
       <Prop1>StringValue</Prop1> 
       <Prop2>11</Prop2> 
    </Data>";
        [DataContract(Name = "Data", Namespace = "")]
        public class Data
        {
            [DataMember(Order = 1)]
            public string Prop1 { get; set; }
            [DataMember(Order = 2)]
            public int Prop2 { get; set; }
        }
        public class MyReader : XmlReader
        {
            XmlReader inner;
            public MyReader(XmlReader inner)
            {
                this.inner = inner;
            }
            public override int AttributeCount
            {
                get { return inner.AttributeCount; }
            }
            public override string BaseURI
            {
                get { return inner.BaseURI; }
            }
            public override void Close()
            {
                inner.Close();
            }
            public override int Depth
            {
                get { return inner.Depth; }
            }
            public override bool EOF
            {
                get { return inner.EOF; }
            }
            public override string GetAttribute(int i)
            {
                return inner.GetAttribute(i);
            }
            public override string GetAttribute(string name, string namespaceURI)
            {
                return inner.GetAttribute(name, namespaceURI);
            }
            public override string GetAttribute(string name)
            {
                return inner.GetAttribute(name);
            }
            public override bool IsEmptyElement
            {
                get { return inner.IsEmptyElement; }
            }
            public override string LocalName
            {
                get { return inner.LocalName; }
            }
            public override string LookupNamespace(string prefix)
            {
                return inner.LookupNamespace(prefix);
            }
            public override bool MoveToAttribute(string name, string ns)
            {
                return inner.MoveToAttribute(name, ns);
            }
            public override bool MoveToAttribute(string name)
            {
                return inner.MoveToAttribute(name);
            }
            public override bool MoveToElement()
            {
                return inner.MoveToElement();
            }
            public override bool MoveToFirstAttribute()
            {
                return inner.MoveToFirstAttribute();
            }
            public override bool MoveToNextAttribute()
            {
                return inner.MoveToNextAttribute();
            }
            public override XmlNameTable NameTable
            {
                get { return inner.NameTable; }
            }
            public override string NamespaceURI
            {
                get
                {
                    if (inner.NamespaceURI == "http://schemas.datacontract.org/2004/07/XYZ")
                    {
                        return "";
                    }
                    else
                    {
                        return inner.NamespaceURI;
                    }
                }
            }
            public override XmlNodeType NodeType
            {
                get { return inner.NodeType; }
            }
            public override string Prefix
            {
                get { return inner.Prefix; }
            }
            public override bool Read()
            {
                return inner.Read();
            }
            public override bool ReadAttributeValue()
            {
                return inner.ReadAttributeValue();
            }
            public override ReadState ReadState
            {
                get { return inner.ReadState; }
            }
            public override void ResolveEntity()
            {
                inner.ResolveEntity();
            }
            public override string Value
            {
                get { return inner.Value; }
            }
        }
        public static void Test()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Data));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
            try
            {
                XmlReader r = XmlReader.Create(ms);
                XmlReader my = new MyReader(r);
                Data d = (Data)dcs.ReadObject(my);
                Console.WriteLine("Data[Prop1={0},Prop2={1}]", d.Prop1, d.Prop2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
