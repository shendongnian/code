    var jObj = JObject.Parse(json);
    var fields = jObj["fields"]
                    .Select(x => new Field
                    {
                        Id = (int)x["id"],
                        Type = (string)x["type"],
                        Value = x["value"] is JValue 
                                ? new Dictionary<string,string>(){{"",(string)x["value"]}}
                                : x["value"].Children()
                                            .Cast<JProperty>()
                                            .ToDictionary(p => p.Name, p => (string)p.Value)
                    })
                    .ToList();
    private class Field
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Value { get; set; }    
    } 
