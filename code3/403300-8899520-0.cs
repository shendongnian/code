    static void Main(string[] args)
        {
            Uri largeUri = new Uri("http://www.rfkbau.de/index.php?option=com_easybook&Itemid=22&startpage=7096");
            foreach (var s in ReadLargePage(largeUri))
            {
                Console.WriteLine(s);
            }
        }
        static IEnumerable<string> ReadLargePage(Uri uri)
        {            
            int bufferSize = 8192;
            int readCount;
            Char[] readBuffer = new Char[bufferSize];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri); 
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		    using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                readCount = stream.Read(readBuffer, 0, bufferSize);
                
				while (readCount > 0) 
			    {                    
                    yield return new string(readBuffer, 0, bufferSize);
                    readCount = stream.Read(readBuffer, 0, bufferSize);
				}
            }
        }
