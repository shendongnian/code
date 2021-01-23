    [Serializable]
    public class Cost
    {
        [XmlElement("Code")]
        public string Code { get; set; }
        [XmlElement("Info")]
        public string Info { get; set; }
    }
    [Serializable]
    public class PurchaseItem
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        
        // XmlArray of Cost
        [XmlArray(ElementName = "Costs")]
        public Cost[] Costs { get; set; }
    }
    public class Tests
    {
        [Test]
        public void Test()
        {
            var serializer = new XmlSerializer(typeof (PurchaseItem));
            var xml = @"<PurchaseItem>
                            <Name>Item 1</Name>
                            <Costs>
                                <Cost>
                                    <Code>A</Code>
                                    <Info>Test 1</Info>
                                </Cost>
                                <Cost>
                                    <Code>B</Code>
                                    <Info>Test 1</Info>
                                </Cost>
                                <Cost>
                                    <Code>C</Code>
                                    <Info>Test 1</Info>
                                </Cost>
                            </Costs>
                        </PurchaseItem>";
            var data = Encoding.UTF8.GetBytes(xml);
            var reader = XmlReader.Create(new MemoryStream(data));
            var item = (PurchaseItem) serializer.Deserialize(reader);
            Assert.AreEqual(item.Costs[0].Code, "A");
            Assert.AreEqual(item.Costs[1].Code, "B");
            Assert.AreEqual(item.Costs[2].Code, "C");
        }
    }
