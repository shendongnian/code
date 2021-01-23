     public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                int test = GetPlusOnes("http://www.allfancydress.com/");
                Response.Write("Plus ones: " + test.ToString());
            }
    
            public static Regex REGEX_GETURLCOUNT =
             new Regex(@"<div[^>]+id=""aggregateCount""[^>]+>(\d*)</div>");
    
            public static int GetPlusOnes(string url)
            {
                string fetchUrl =
                    "https://plusone.google.com/u/0/_/+1/fastbutton?url=" +
                    HttpUtility.UrlEncode(url) + "&count=true";
                HttpWebRequest request =
                    (HttpWebRequest)WebRequest.Create(fetchUrl);
                string response = new StreamReader(request.GetResponse()
                    .GetResponseStream()).ReadToEnd();
                Match match = REGEX_GETURLCOUNT.Match(response);
                if (match.Success)
                {
                    return int.Parse(match.Groups[1].Value);
                }
                return 0;
            }
    
        }
