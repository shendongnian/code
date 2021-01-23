    using System;
    using System.Web;
    class MainClass
    {
        public static void Main (string[] args)
        {
            Uri uri = new Uri("https://www.google.com/url?q=http://www.site.net/file.doc&sa=U&ei=_YeOUc&ved=0CB&usg=AFQjCN-5OX");
            Uri doc = new Uri (HttpUtility.ParseQueryString (uri.Query).Get ("q"));
            Console.WriteLine (doc);
        }
    }
