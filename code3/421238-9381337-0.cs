    public IEnumerable<string> Data = new List<string>() {
      "Text1\tValue1\tAnotherValue1\t",
      "Text2\tValue2\tAnotherValue2\t",
      "Text3\tValue3\tAnotherValue3\t",
      "Text4\tValue4\tAnotherValue4\t",
      "Text5\tValue5\tAnotherValue5\t",
      "Text6\tValue6\tAnotherValue6\t",
      "Text7\tValue7\tAnotherValue7\t",
      "Text8\tValue8\tAnotherValue8\t"
    };
    public class MyData {
       public String SomeText { get; set; }
       public String Value { get; set; }
       public String AnotherValue { get; set; }
    }
    [TestMethod]
    public void ParseAndFind() {
            var dictionary = Data.Select(line =>
            {
                var pieces = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                return new MyData {
                    SomeText = pieces[0],
                    Value = pieces[1],
                    AnotherValue = pieces[2],
                };
            }).ToDictionary<MyData, string>(dat =>dat.SomeText);
            Assert.AreEqual("AnotherValue3", dictionary["Text3"].AnotherValue);
            Assert.AreEqual("Value7", dictionary["Text7"].Value);
    }
