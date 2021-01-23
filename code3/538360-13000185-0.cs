    [TestFixture]
    public class SerializeOscTest
    {
        [Test]
        public void SerializeEmpTest()
        {
            var oscMethods = new List<OscMethod>
                                 {
                                      new OscMethod<float> {Value = 0f}, 
                                      new OscMethod<float[]> {Value = new float[] {10,0}}
                                  };
            string xmlString = oscMethods.GetXmlString();
        }
    }
    public class OscMethod<T> : OscMethod
    {
        public T Value { get; set; }
    }
    [XmlInclude(typeof(OscMethod<float>)),XmlInclude(typeof(OscMethod<float[]>))]
    public abstract class OscMethod
    {
        
    }
    public static class Extenstion
    {
        public static string GetXmlString<T>(this T objectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());
            StringBuilder stringBuilder = new StringBuilder();
            string xml;
            using (var xmlTextWriter = new XmlTextWriter(new StringWriter(stringBuilder)))
            {
                xmlSerializer.Serialize(xmlTextWriter, objectToSerialize);
                xml = stringBuilder.ToString();
            }
            return xml;
        }
    }
