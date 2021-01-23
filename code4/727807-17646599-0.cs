        public static string getEpochSeconds()
        {
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            //t	{15901.03:57:53.6052183}	System.TimeSpan
            var timestamp1 = t.TotalSeconds;
            //timestamp1	1373860673.6052184	double
            var tstring1 = timestamp1.ToString("N6");
            //tstring1	"1,373,860,673.605220"	string
            var timestamp = (long)(t.TotalSeconds * 1000000);
            //timestamp	1373860673605218	long
            string tstring =timestamp.ToString();
            //tstring	"1373860673605218"	string
            tstring = tstring.Substring(0, tstring.Length - 6) + "." + tstring.Substring(tstring.Length - 6);
            //tstring	"1373860673.605218"	string
            return tstring;
        }
