        static void Main(string[] args)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(
                @"http://www.ctabustracker.com/bustime/api/v1/gettime?key=89dj2he89d8j3j3ksjhdue93j"
                );
            using (WebResponse resp = req.GetResponse())
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    using(StreamReader reader = new StreamReader(respStream))
                    {
                        String respString = reader.ReadToEnd();
                        Debug.WriteLine(respString);
                        TestBusTimeResponse response = XmlUtil.DeserializeString<TestBusTimeResponse>(respString);
                        Debug.WriteLine(response.Error.Message);
                    }
                }
            }
            Console.ReadLine();
        }
