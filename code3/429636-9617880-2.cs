    [XmlRoot("error")]
    public class TestBusTimeResponseError
    {
        [XmlElement("msg")]
        public String Message
        {
            get;
            set;
        }
    }
    // Response in the following format:
    // <?xml version="1.0"?>
    // <bustime-response><error><msg>Invalid API access key supplied</msg></error></bustime-response>
    [XmlRoot("bustime-response")]
    public class TestBusTimeResponse
    {
        [XmlElement("error")]
        public TestBusTimeResponseError Error
        {
            get;
            set;
        }
    }
