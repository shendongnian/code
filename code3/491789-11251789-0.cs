    public class CHtmlPraseDemo
    {
        private string strHtmlSource;
        public mshtml.IHTMLDocument2 oHtmlDoc;
        public CHtmlPraseDemo(string url)
        {
            GetWebContent(url);
            oHtmlDoc = (IHTMLDocument2)new HTMLDocument();
            oHtmlDoc.write(strHtmlSource);
        }
        public List<String> GetTdNodes(string TdClassName)
        {
            List<String> listOut = new List<string>();
            IHTMLElement2 ie = (IHTMLElement2)oHtmlDoc.body;
            IHTMLElementCollection iec = (IHTMLElementCollection)ie.getElementsByTagName("td");
            foreach (IHTMLElement item in iec)
            {
                if (item.className == TdClassName)
                {
                    listOut.Add(item.innerHTML);
                }
            }
            return listOut;
        }
        void GetWebContent(string strUrl)
        {
            WebClient wc = new WebClient();
            strHtmlSource = wc.DownloadString(strUrl);
        }
    }
    class Program
    {
     static void Main(string[] args)
        {
            CHtmlPraseDemo oH = new CHtmlPraseDemo("http://stackoverflow.com/faq");
            
            Console.Write(oH.oHtmlDoc.title);
            List<string> l = oH.GetTdNodes("x");
            foreach (string n in l)
            {
                Console.WriteLine("new td");
                Console.WriteLine(n.ToString());
                
            }
            Console.Read();
        }
    }
