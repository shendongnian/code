    public static decimal Convert(decimal amount, string from, string to)
            {
                WebClient web = new WebClient();
      
                string url = string.Format("http://www.google.com/ig/calculator?hl=en&q={0}{1}=?{2}", amount, from.ToUpper(), to.ToUpper());
      
                string response = web.DownloadString(url);
      
                Regex regex = new Regex("rhs: \\\"(\\d*.\\d*)");
                Match match = regex.Match(response);
      
                return System.Convert.ToDecimal(match.Groups[1].Value);
            }
