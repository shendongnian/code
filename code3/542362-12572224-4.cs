    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    
    namespace Foo.Client
    {
        public class Website
        {
            public string Html { get; private set; }
    
            private Website(string html)
            {
                Html = html;
            }
    
            public static Website Load(Uri uri)
            {
                validate(uri);
                return new Website(getPageContentFor(uri));
            }
    
            public List<string> GetHyperLinks()
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(Html);
                return extractLinksFrom(doc.DocumentNode.SelectNodes("//a[@href]"));
            }
    
            private static string getPageContentFor(Uri uri)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(uri);
                    var response = (HttpWebResponse)request.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        return reader.ReadToEnd();
                }
                catch (WebException)
                {
                    return String.Empty;
                }
            }
    
            private List<string> extractLinksFrom(HtmlNodeCollection nodes)
            {
                var result = new List<string>();
                if (nodes == null) return result;
                foreach (var link in nodes)
                        result.Add(link.Attributes["href"].Value);
                return result;
            }
    
            private static void validate(Uri uri)
            {
                if (!uri.IsAbsoluteUri)
                    throw new ArgumentException("invalid uri format");
            }
        }
    }
