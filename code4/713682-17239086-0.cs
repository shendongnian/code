    using System;
    using System.Net;
    using Myapp.Properties;
    namespace MyApp
    {
        public class Test
        {
            static void Main(string[] args)
            {
            string website ="http://www.fryan0911.com/webclientsample.zip";
            string downloadfolder = Settings.Default.DownloadFolder;
            try
                {
                WebClient wc = new WebClient();
                wc.DownloadFile(website, downloadfolder);
                Console.WriteLine("Web file has been downloaded to " + downloadfolder);
                }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
    }
