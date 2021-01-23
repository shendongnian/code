    public class XmlMapping //class under test
    {
        static XmlMapping()
        {
            // Default the handler to the normal call to Deserialize
            DeserializeHandler = Deserialize;
        }
        public static XmlMapping Create(string filename) //method under test
        {
            //deserialize xml to object of type XmlMapping
            //preudocode:
            var result = DeserializeHandler(string.Format("{0}.xml",filename));
            //...
            return result;
        }
        // Abstract indirection function to allow you to swap out Deserialize implementations
        internal static Func<string, XmlMapping> DeserializeHandler { get; set; }
        private static XmlMapping Deserialize(string fileName)
        {
            return new XmlMapping();
        }
    }
    public class CreateTests {
        public void CallingDeserializeProperly()
        {
            
            // Arrange
            var called = false;
            Func<string, XmlMapping> fakeHandler = (string f) =>
            {
                called = true; // do your test of the input and put your result here
                return new XmlMapping();
            };
            // Act
            XmlMapping.DeserializeHandler = fakeHandler;
            var m = XmlMapping.Create("test");
           
            // Assert
            Assert.IsTrue(called);
        }
    }
