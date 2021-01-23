    public class Test
    {
        public static void Main (string[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ApplicationException ("Specify the URI of the resource to retrieve.");
            }
            var client = new WebClient ();
            var s = client.DownloadString (args[0]);
            // var data = client.OpenRead(args[0]);
            // var reader = new StreamReader(data);
            // var s = reader.ReadToEnd();
            var myIP = "100.100.100.100";
            var ipFound = s.Contains(myIP);
            Console.WriteLine("Is my IP in the web page?: {0}", b);
            data.Close ();
            reader.Close ();
        }
    }
