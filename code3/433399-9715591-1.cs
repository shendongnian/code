    public class Properties {
        public static string Url {get;set;}
    }
    ...
    Properties.Url = "http://foo.com/bar/";
    ...
    string url = Properties.Url;
