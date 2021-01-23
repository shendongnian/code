    public class HtmlItem
    {
       [DataMember(Name = "html")]
       public string Html { get; set; }
    }
    
    JavaScriptSerializer ser = new JavaScriptSerializer();          
    
    // Serialize
    string html = ser.Serialize(new List<HtmlItem> {
       new HtmlItem {  Html = "foo" },
       new HtmlItem {  Html = "bar" }
    });
    	
    // Deserialize and print the html items.		
    List<HtmlItem> htmlList = ser.Deserialize<List<HtmlItem>>(html);
    htmlList.ForEach((item) => Console.WriteLine(item.Html)); // foo bar
