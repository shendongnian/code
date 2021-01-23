    using System.Web;
...
    string value1 = "&lt;html&gt;";
    string value2 = HttpUtility.HtmlDecode(value1);
    string value3 = HttpUtility.HtmlEncode(value2);
    Debug.WriteLine(value1);
    Debug.WriteLine(value2);
    Debug.WriteLine(value3);
