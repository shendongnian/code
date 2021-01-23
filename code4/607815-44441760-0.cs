    using System;
    using HtmlAgilityPack;    
    class Traslator
        {
            private string url;
            private HtmlWeb web;
            private HtmlDocument htmlDoc;
    
            public Translator(string langPair) // LangPair = "SL|TL" ( Source Lang | Target Lang - Ex.: "en|pt"
            {
                this.url = "http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair=" + langPair;
                this.web = new HtmlWeb();
                this.htmlDoc = new HtmlDocument();
            }
    
            public string Translate(string input)
            {
                this.htmlDoc = web.Load(String.Format(this.url, Uri.EscapeUriString(input)));
                HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"result_box\"]");
                return htmlNode.InnerText;
            }
        }
