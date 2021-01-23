    var main = JObject.Parse(json);
            foreach (var mainRoute in main.Properties()) // this is "posts"
            {
                foreach (var subRoute in mainRoute.Values<JObject>().SelectMany(x => x.Properties())) // this is "Pippo", "Pluto"
                {
                    var deserialized = JsonConvert.DeserializeObject<postModel>(subRoute.Value.ToString());
                    new postModel
                    {
                        text = deserialized.text,
                        link = deserialized.link
                    };
                }
            }
