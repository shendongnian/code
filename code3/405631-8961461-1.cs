       public void Talk()
       {
            string xmlResult = null;
            Result result = null;  // Result declared at the end 
            string botId = "c49b63239e34d1"; // enter your botid
            string talk = "Am I a human?"; 
            string custId = null; // (or a value )
            using (var wc = new WebClient())
            {
                var col = new NameValueCollection();
                col.Add("botid", botId);
                col.Add("input", talk);
                if (!String.IsNullOrEmpty(custId))
                {
                    col.Add("custid", custId);
                }
                byte[] xmlResultBytes = wc.UploadValues(
                    @"http://www.pandorabots.com/pandora/talk-xml", 
                    "POST", 
                    col);
                xmlResult = UTF8Encoding.UTF8.GetString(xmlResultBytes);
                result = Result.GetInstance(xmlResultBytes);
            }
            //raw result
            Console.WriteLine(xmlResult);
            
            // use the Result class
            if (result.status == 0)  // no error
            {
                Console.WriteLine("{0} -> {1}", 
                    result.input, result.that);
            }
            else  // error
            {
                Console.WriteLine("Error: {0} : {1}", 
                    result.input, result.message);
            }
        }
    [XmlRoot(ElementName="result")]
    public class Result
    {
        static XmlSerializer ser = new XmlSerializer(typeof(Result) , "");
        public Result()
        {
        }
        public static Result GetInstance(byte[] bytes)
        {
            return (Result)ser.Deserialize(new MemoryStream(bytes));
        }
        [XmlAttribute]
        public int status { get; set; }
        [XmlAttribute]
        public string botid { get; set; }
        [XmlAttribute]
        public string custid { get; set; }
        [XmlElement]
        public string input { get; set; }
        [XmlElement]
        public string that { get; set; }
        [XmlElement]
        public string message { get; set; }
    }
