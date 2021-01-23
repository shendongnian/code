    // This is the test class we want to 
    // serialize:
    [Serializable()]
    public class TestClass
    {
        private string someString;
        public string SomeString
        {
            get { return someString; }
            set { someString = value; }
        }
     
        private List<string> settings = new List<string>();
        public List<string> Settings
        {
            get { return settings; }
            set { settings = value; }
        }
     
        // These will be ignored
        [NonSerialized()]
        private int willBeIgnored1 = 1;
        private int willBeIgnored2 = 1;
     
    }
     
    // Example code
     
    // This example requires:
    // using System.Xml.Serialization;
    // using System.IO;
     
    // Create a new instance of the test class
    TestClass TestObj = new TestClass();
     
    // Set some dummy values
    TestObj.SomeString = "foo";
     
    TestObj.Settings.Add("A");
    TestObj.Settings.Add("B");
    TestObj.Settings.Add("C");
     
     
    #region Save the object
     
    // Create a new XmlSerializer instance with the type of the test class
    XmlSerializer SerializerObj = new XmlSerializer(typeof(TestClass));
     
    // Create a new file stream to write the serialized object to a file
    TextWriter WriteFileStream = new StreamWriter(@"C:\test.xml");
    SerializerObj.Serialize(WriteFileStream, TestObj);
     
    // Cleanup
    WriteFileStream.Close();
     
    #endregion
     
     
    /*
    The test.xml file will look like this:
     
    <?xml version="1.0"?>
    <TestClass xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <SomeString>foo</SomeString>
      <Settings>
        <string>A</string>
        <string>B</string>
        <string>C</string>
      </Settings>
    </TestClass>		 
    */
     
    #region Load the object
     
    // Create a new file stream for reading the XML file
    FileStream ReadFileStream = new FileStream(@"C:\test.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
     
    // Load the object saved above by using the Deserialize function
    TestClass LoadedObj = (TestClass)SerializerObj.Deserialize(ReadFileStream);
     
    // Cleanup
    ReadFileStream.Close();
     
    #endregion
     
     
    // Test the new loaded object:
    MessageBox.Show(LoadedObj.SomeString);
     
    foreach (string Setting in LoadedObj.Settings)
        MessageBox.Show(Setting);
