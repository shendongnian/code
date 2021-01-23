    string input = "&lt;span&gt;i am &lt;strong color=blue&gt;very&lt;/strong&gt; big &lt;br&gt;man.&lt;/span&gt;";
    string output = "&lt;span&gt;i am <strong color=blue>very</strong> big <br>man.&lt;/span&gt;";
    
    var decoded = HttpUtility.HtmlDecode(output);
    var encoded =input ; //  HttpUtility.HtmlEncode(decoded);
    
    Console.WriteLine(encoded);
    Console.WriteLine(decoded);
    
    var doc=CsQuery.CQ.CreateDocument(decoded);
    
    var paras=doc.Select("strong").Union(doc.Select ("br")) ;
    
    var tags=new List<KeyValuePair<string, string>>();
    var counter=0;
    
    foreach (var element in paras)
    {
    	HttpUtility.HtmlEncode(element.OuterHTML).Dump();
    	var key ="---" + counter + "---";
    	var value= HttpUtility.HtmlDecode(element.OuterHTML);
    	var pair= new KeyValuePair<String,String>(key,value);
    	
    	element.OuterHTML = key ;
    	tags.Add(pair);
    	counter++;
    }
    
    var finalstring= HttpUtility.HtmlEncode(doc.Document.Body.InnerHTML);
    finalstring.Dump();
    
    foreach (var element in tags)
    {
    finalstring=finalstring.Replace(element.Key,element.Value);
    }
    
    Console.WriteLine(finalstring);
