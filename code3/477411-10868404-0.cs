            static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0");
            string str = client.DownloadString("http://www.scirus.com/srsapp/search?q=core+facilities&t=all&sort=0&g=s"); 
            byte[] bit = new System.Text.ASCIIEncoding().GetBytes(str);
            FileStream fil = File.OpenWrite("test.txt");
            fil.Write(bit,0,bit.Length);
        }
