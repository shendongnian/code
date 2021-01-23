    public class Program
    {
        static void Main()
        {
            var doc = XDocument.Parse(
                @"<html>
                  <p>xxxx</p>
                  <pre>xxx</pre>
                  <p>xxxx</p>
                  <pre>yyy</pre>
                </html>"
            );
            foreach (var pre in doc.Descendants("pre"))
    	    {
                pre.Value = string.Format("ABC {0} ABC", pre.Value);		 
    	    }
            Console.WriteLine(doc);
        }
    }
