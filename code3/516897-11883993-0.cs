            [Test]
            public void TestHack()
            {
                string almost = "{tags=[tag1,tag2]}";
                string json = this.HackToJson(almost);
                Trace.WriteLine(json);
            }
            public string HackToJson(string almostJson)
            {
                if( almostJson.StartsWith("{tags=[") && almostJson.EndsWith("]}"))
                {
                    int tagsLen = "{tags=[".Length;
                    string tags = almostJson.Substring(tagsLen, almostJson.Length - (tagsLen + 2));
    
                    var items = tags.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    
                    var itemsCleaned = (from c in items select "\"" + c.Trim() + "\"");
    
                    var jsonpart = string.Join(",", itemsCleaned);
    
                    var json = string.Format("{{tags=[{0}]}}", jsonpart);
    
                    return json;
    
                }
                throw new NotImplementedException("not sure what to do here... ");
            }
