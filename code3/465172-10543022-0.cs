            string json = @"{
              ""data"": [
                {
                  ""installed"": 1,
                  ""user_likes"": 1,
                  ""user_education_history"": 1,
                  ""friends_education_history"": 1,
                  ""bookmarked"": 1
                }
              ]
            }";
            JObject j = JObject.Parse(json);
            // Directly traversing the graph
            var lst = j["data"][0].Select(jp => ((JProperty)jp).Name).ToList();
            Console.WriteLine(string.Join("--", lst));
            
            // Using SelectToken
            lst = j.SelectToken("data[0]").Children<JProperty>().Select(p => p.Name).ToList();
            Console.WriteLine(string.Join("--", lst));
