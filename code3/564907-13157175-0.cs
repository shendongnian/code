    [TestFixture]
    public class DataContractSerializerTests
    {
        [Test]
        public void ArrayOfObjectsTest()
        {
            var dataContracClass = new DataContractClass() 
                { 
                   Objects = new object[] { "Johan", 1 } 
                };
            StringBuilder sb = new StringBuilder();
            DataContractSerializer ser = new DataContractSerializer(dataContracClass.GetType());
            using (XmlWriter xmlWriter = XmlWriter.Create(sb))
            {
                ser.WriteObject(xmlWriter,dataContracClass);
            }
            string s = sb.ToString();
        }
    }
