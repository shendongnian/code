    public partial class SearchResults : System.Web.UI.Page
    {
        private class SomeSearchableClass
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // The autocomplete plugin defaults to using the querystring
            // parameter "term". This can be confirmed by stepping through
            // the following line of code and viewing the raw querystring.
            List<SomeSearchableClass> Results = SomeSearchSource(Request.QueryString["term"]);
    
            Response.ContentType = "application/json;charset=UTF-8";
    
            // Now we need to project our results in a structure that
            // the plugin can understand.
    
            var output = (from r in Results
                            select new { label = r.Name, value = r.ID }).ToList();
    
            // Then we need to convert it to a JSON string
    
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            string JSON = Serializer.Serialize(output);
    
            // And finally write the result to the client.
    
            Response.Write(JSON);
        }
    
        List<SomeSearchableClass> SomeSearchSource(string searchParameter)
        {
            // This is where you'd put your EF code to gather your search
            // results. I'm just hard coding these examples as a demonstration.
    
            List<SomeSearchableClass> ret = new List<SomeSearchableClass>();
    
            ret.Add(new SomeSearchableClass() { ID = 1, Name = "Watership Down" });
            ret.Add(new SomeSearchableClass() { ID = 2, Name = "Animal Farm" });
            ret.Add(new SomeSearchableClass() { ID = 3, Name = "The Plague Dogs" });
    
            ret = ret.Where(x => x.Name.Contains(searchParameter)).ToList();
    
            return ret;
        }
    }
