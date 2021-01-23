    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CookieContainer cookieJar = new CookieContainer();
            HTTP http = new HTTP(cookieJar);
            string user = "id";
            string pass = "password";
            //some cookies are set before login & they are needed for an user to login, for that reason only you were getting the error
            string responseData = http.DownloadString("https://signin.ebay.com/ws/eBayISAPI.dll?SignIn");
            string midParamValue = ParseMid(responseData, "name=\"mid\" id=\"mid\" value=\"", "\"");
            string bUrlPrfx = ParseMid(responseData, "id=\"bUrlPrfx\" value=\"", "\"");
            string rqid = ParseMid(responseData, "id=\"bUrlPrfx\" value=\"", "\"");
            string hidUrl = ParseMid(responseData, "name=\"hidUrl\" value=\"", "\""); //"name=\"hidUrl\" value="http://my.ebay.com/ws/eBayISAPI.dll?MyeBay"
            //string lucky9 = ParseMid(responseData, 
            string pdata =
                string.Format(
                    "MfcISAPICommand=SignInWelcome&bhid=a1%253Dna%7Ea2%253Dna%7Ea3%253Dna%7Ea4%253DMozilla%7Ea5%253DNetscape%7Ea6%253D5.0%2520%28Windows%29%7Ea7%253D20100101%7Ea8%253Dna%7Ea9%253Dtrue%7Ea10%253DWindows%2520NT%25206.1%253B%2520WOW64%7Ea11%253Dtrue%7Ea12%253DWin32%7Ea13%253Dna%7Ea14%253DMozilla%252F5.0%2520%28Windows%2520NT%25206.1%253B%2520WOW64%253B%2520rv%253A18.0%29%2520Gecko%252F20100101%2520Firefox%252F18.0%7Ea15%253Dfalse%7Ea16%253Den-US%7Ea17%253Dna%7Ea18%253Dsignin.ebay.com%7Ea19%253Dna%7Ea20%253Dna%7Ea21%253Dna%7Ea22%253Dna%7Ea23%253D1366%7Ea24%253D768%7Ea25%253D24%7Ea26%253D738%7Ea27%253Dna%7Ea28%253DFri%2520Jan%252025%25202013%252022%253A20%253A09%2520GMT%252B0530%2520%28India%2520Standard%2520Time%29%7Ea29%253D5.5%7Ea30%253Dpdf%257Cpdf%257Cpdf%257C%7Ea31%253Dyes%7Ea32%253Dna%7Ea33%253Dna%7Ea34%253Dno%7Ea35%253Dno%7Ea36%253Dyes%7Ea37%253Dno%7Ea38%253Donline%7Ea39%253Dno%7Ea40%253DWindows%2520NT%25206.1%253B%2520WOW64%7Ea41%253Dno%7Ea42%253Dno%7Ea43%253D&UsingSSL=1&inputversion=2&lse=true&lsv=11.5.502&mid=AQAAAThpCRHvAAUxMzg5OTM0YzA2MS5hNWFiODMyLjJmNDcyLmZmZTlhOWUwEZMPFiRFo7yUjykHfCAFgp%2Bk9%2Bk*&kgver=1&kgupg=1&kgstate=r&omid=&hmid=&rhr=f&siteid=0&co_partnerId=2&ru=&pp=&pa1=&pa2=&pa3=&i1=-1&pageType=-1&rtmData=&bUrlPrfx={0}&rqid={1}&kgct=&userid={2}&pass={3}&keepMeSignInOption=1&sgnBt=Sign+in&htmid={4}&kdata=%251E%251F%2510%251E1359132609409%251E1%251F%2510%251E1359132609409%251E0%251F%2510%251E1359132609410%251E1%251F%2510%251E1359132609410%251E0%251F%251B%251E1359132612808%251E1%251F%2510%251E1359132612837%251E1%251F%2510%251E1359132612838%251E0%251F%251B%251E1359132612977%251E0%251F", bUrlPrfx, rqid, user, pass, midParamValue);
            responseData =
                http.UploadString("https://signin.ebay.com/ws/eBayISAPI.dll?co_partnerId=2&siteid=0&UsingSSL=1", pdata);
            richTextBox1.Text = responseData;
            PrintAllCookies(cookieJar);
        }
        private void PrintAllCookies(CookieContainer cookies)
        {
            Hashtable table = (Hashtable)cookies.GetType().InvokeMember("m_domainTable",
                                                                         BindingFlags.NonPublic |
                                                                         BindingFlags.GetField |
                                                                         BindingFlags.Instance,
                                                                         null,
                                                                         cookies,
                                                                         new object[] { });
            foreach (string key in table.Keys)
            {
                foreach (Cookie cookie in cookies.GetCookies(new Uri(string.Format("http://{0}/", key.StartsWith(".", StringComparison.Ordinal) ? "www" + key : key))))
                {
                    richTextBox1.AppendText("Name = " + cookie.Name.ToString() + " Value = " + cookie.Value.ToString() + "Domain = " + cookie.Domain.ToString() + "\n\n");
                }
            }
        }
        public string ParseMid(string text, string firstString, string lastString)
        {
            string str = text;
            int pos1 = str.IndexOf(firstString, StringComparison.Ordinal) + firstString.Length;
            int pos2 = str.IndexOf(lastString, pos1 + 1, StringComparison.Ordinal);
            string finalString = str.Substring(pos1, pos2 - pos1);
            return finalString;
        }
        public class HTTP : WebClient
        {
            public HTTP()
                : this(new CookieContainer())
            { }
            public HTTP(CookieContainer c)
            {
                CookieContainer = c;
            }
            public CookieContainer CookieContainer { get; set; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                var castRequest = request as HttpWebRequest;
                if (castRequest != null)
                {
                    castRequest.CookieContainer = CookieContainer;
                    castRequest.ServicePoint.Expect100Continue = false;
                    castRequest.ContentType = "application/x-www-form-urlencoded";
                    //castRequest.AllowAutoRedirect = true;
                    castRequest.Headers.Add("Cache-Control", "max-age=0");
                    castRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    castRequest.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                    //castRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                    castRequest.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    castRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17";
                    castRequest.Headers.Add("Origin", "https://signin.ebay.com");
                    castRequest.Referer = "https://signin.ebay.com/ws/eBayISAPI.dll?SignIn";
                    castRequest.KeepAlive = true;
                    castRequest.Host = "signin.ebay.com";
                }
                return request;
            }
        }
    }
    }
