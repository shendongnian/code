    [Test]
    public void RoundTrip()
    {
        var response = new Response
                            {
                                schema = "Listing",
                                data = new ListingData
                                            {
                                                key = "28ba648c-de24-45d4-a7d9-70f810cf5438",
                                                children = new List<object>
                                                                {
                                                                    new Type1
                                                                        {
                                                                            body = "Four score and seven years ago...",
                                                                            parent_id = "2qh3l",
                                                                            report_count = 0,
                                                                            name = "c4j6yeh"
                                                                        },
                                                                    new Type3
                                                                        {
                                                                            domain = "abc.def.com",
                                                                            flagged = true,
                                                                            category = "news",
                                                                            saved = false,
                                                                            id = "t3dz0",
                                                                            created = 1335998011.0
                                                                        }
                                                                }
                                            }
                            };
    
        var jsonSerializerSettings = new JsonSerializerSettings
                                            {
                                                Formatting = Formatting.Indented,
                                                TypeNameHandling = TypeNameHandling.Objects
                                            };
    
        string serializedResponse = JsonConvert.SerializeObject(response, jsonSerializerSettings);
        Console.WriteLine(serializedResponse);
        var roundTrippedResponse = JsonConvert.DeserializeObject<Response>(serializedResponse, jsonSerializerSettings);
        Assert.That(roundTrippedResponse.data.children.First().GetType(), Is.EqualTo(typeof(Type1)));
        Assert.That(roundTrippedResponse.data.children.Last().GetType(), Is.EqualTo(typeof(Type3)));
    }
