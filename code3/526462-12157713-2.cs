    .
    .
    .
    var request1 = new WebTestRequest("http://localhost/Home/Index");
    var sessionId = "";
    request1.ExtractValues += (s, e) => {
    sessionId = 
      e.Response.HtmlDocument.HtmlTags.SingleOrDefault(tag => 
         tag.Name == "somename" 
         && tag.Attributes.Any(a => a.Name == "attrName" 
         && a.Value == "attrValue"));    
    };
    
    yield return request1;
