    class Program
        {
            private static string _scheme = string.Empty;
            private static string _host = string.Empty;
            private static string _sub = string.Empty;
    
            static void Main(string[] args)
            {
                ParseUri("rtsp://192.168.1.100:554/videocam/media/1/video/1");
                ParseUri("192.168.1.100/videocam/media/1/video/1");
                ParseUri("192.168.1.100:6000/media/1/video/1");
                ParseUri("192.168.1.100:6000/videocam");
                // example of adding a new sub
                Sub.Add("sample");
                ParseUri("192.168.1.100:6000/sample/");
                Console.ReadLine();
            }
    
            private static void ParseUri(string URI)
            {
                UriBuilder uri = new UriBuilder(URI);
                _scheme = uri.Scheme;
                _host = uri.Host;
                _sub = string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach (string s in uri.Uri.Segments)
                {
                    if (Sub.Contains(s.Replace("/","")))
                    {_sub = s;}
                    else
                    { sb.Append(s); }
                }
    
                Console.Out.WriteLine("+++++++++++++");
                Console.Out.WriteLine("URI: {0}",URI);
                Console.Out.WriteLine("Scheme: {0}", _scheme);
                Console.Out.WriteLine("sub: {0}",_sub);
                Console.Out.WriteLine("mediaControl: {0}", sb.ToString());
            }
    
            private static List<string> Sub
            {
                get
                {
                    List<string> sub = new List<string>();
                    sub.Add("videocam");
                    return sub;
                }
            }
        }
