    public class Program
    {
        static void Main()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(
                @"<p>xxxx</p>
                  <pre>xxx</pre>
                  <p>xxxx</p>
                  <pre>yyy</pre>"
            );
            foreach (var pre in doc.DocumentNode.Descendants("pre"))
    	    {
                pre.InnerHtml = string.Format("ABC {0} ABC", pre.InnerHtml);		 
    	    }
            Console.WriteLine(doc.DocumentNode.OuterHtml);
        }
    }
