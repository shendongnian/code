           public static void Main(string[] args)
            {   
                if (args == null || args.Length != 1)
                {
                    Console.WriteLine("Specify the URL to receive the request.");
                    Environment.Exit(1);
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args[0]);
                request.CookieContainer = new CookieContainer();
    
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
    
    
    
                // Print the properties of each cookie.
                foreach (Cookie cook in response.Cookies)
                {                    
                    // Show the string representation of the cookie.
                    Console.WriteLine ("String: {0}", cook.ToString());
                }
            }
