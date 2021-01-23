     Expression<Func<List<Item>> createListOfItems = () => new List<Item>
            {
                new Item
                {
                Name = "xyz",
                TagTypes = new List<TagTypes>
                    {
                        new TagTypes
                        {
                            Name = "Genre",
                            Tags = new List<Tags>
                                {
                                new Tags
                                    {
                                        TagName = "tag1"
                                    },
                                new Tags
                                    {
                                        TagName = "tag2"
                                    }        
                                }
                        }
                    }
               }
            };
