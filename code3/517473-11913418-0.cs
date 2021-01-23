    // make sure search terms are passed in, and remove blank entries
    var searchTerms = Request["searchTerms"] == null ? 
                        new string[] {} : 
                        Request["searchTerms"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    // build the list of query items using parameterization
    var searchTermBits = new List<string>();
    for (var i=0; i<searchTerms.Length; i++) {
        searchTermBits.Add("bucketname LIKE @" + i);
    }
    // create your sql command using a join over the array
    var query = "SELECT * FROM buckets";
    if (searchTerms.Length > 0) {
      query += " WHERE " + string.Join(" AND ", searchTermBits);  
    } 
    // ask the database using a lambda to add the %
    var db = Database.Open("StarterSite");
    var results = db.Query(query, searchTerms.Select(x => "%" + x + "%").ToArray());
    
    // enjoy!
    Response.Write(results.Count());
