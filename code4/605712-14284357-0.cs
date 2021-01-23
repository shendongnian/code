    public class StackOverflow_14281800
    {
        [ServiceContract]
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class EmailService
        {
            [WebInvoke(UriTemplate = "/SendEmail", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Xml)]
            public bool SendEmail(EmailData data)
            {
                try
                {
                    Console.WriteLine("data.FileName = " + data.FileName);
                    Console.WriteLine("data.EmailAddress = " + data.EmailAddress);
                    Console.WriteLine("data.FileContents = " + new string(Convert.FromBase64String(data.Enc64FileContents).Select(b => (char)b).ToArray()));
                    //byte[] fileBinaryContents = Convert.FromBase64String(data.Enc64FileContents);
                    //File.WriteAllBytes(data.FileName, fileBinaryContents);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        [DataContract(Name = "EmailData", Namespace = "http://somenamespace/")]
        public class EmailData
        {
            [DataMember(Order = 1)]
            public string FileName { get; set; }
            [DataMember(Order = 2)]
            public string EmailAddress { get; set; }
            [DataMember(Order = 3)]
            public string Enc64FileContents { get; set; }
        }
        public static void Test()
        {
            string baseURI = "http://localhost:59961/EmailService";
            var host = new WebServiceHost(typeof(EmailService), new Uri(baseURI));
            host.Open();
            Console.WriteLine("Host opened");
            string URI = baseURI + "/SendEmail";
            //string fileContents = Convert.ToBase64String(File.ReadAllBytes("test.txt"));
            string fileContents = Convert.ToBase64String("hello world".Select(c => (byte)c).ToArray());
            EmailData emailData = new EmailData
            {
                EmailAddress = "foo@bar.com",
                Enc64FileContents = fileContents,
                FileName = "test.txt"
            };
            XNamespace ns = "http://somenamespace/";
            XElement emailDataElement = new XElement(ns + "EmailData");
            emailDataElement.Add(new XElement(ns + "FileName", emailData.FileName));
            emailDataElement.Add(new XElement(ns + "EmailAddress", emailData.EmailAddress));
            emailDataElement.Add(new XElement(ns + "Enc64FileContents", emailData.Enc64FileContents));
            var xml = emailDataElement.ToString(SaveOptions.DisableFormatting);
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/xml; charset=utf-8";
                string response = wc.UploadString(URI, "POST", xml);
                Console.WriteLine(response);
            }
        }
    }
