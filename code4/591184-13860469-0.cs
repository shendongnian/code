    public class AsyncWrapper
    {
        public event Action<string> RunCompleted;
        public void Run(Uri url, string requestString, string responseString, WebHeaderCollection headerCollection)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(RunThread));
            thread.start(new [] { url, requestString, responseString, headerCollection });
        }
        public void RunThread(object Obj)
        {
            object[] ObjArray = (object[])Obj;
            Uri url = (Uri)ObjArray[0];
            string requestString = (string)ObjArray[1];
            string responseString = (string)ObjArray[2];
            WebHeaderCollection headerCollection = (WebHeaderCollection)ObjArray[3];
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers = headerCollection;
            request.BeginGetRequestStream((s) => 
            {
                var req = (HttpWebRequest)s.AsyncState;
                var str = req.EndGetRequestStream(s);
                System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
                Byte[] bytes = encoding.GetBytes(responseString);
                str.Write(bytes, 0, bytes.Length);
                str.Close();
                req.BeginGetResponse((k) => 
                {
                    var req2 = (HttpWebRequest)k.AsyncState;
                    var resp = (HttpWebResponse)req2.EndGetResponse(k);
                    byte[] bytes2 = ReadFully(resp.GetResponseStream());
                    string res = System.Text.Encoding.Unicode.GetString(bytes2);
                }, req);
            }, null);
            if (RunComleted != null)
            {
                RunCompleted(res);
            }
        }
        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
