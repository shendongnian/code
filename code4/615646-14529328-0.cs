        public  class ElementName
        {
            public string AccountName { get; set; }
            public string CampaignName { get; set; }
            public string DocumentName { get; set; }
            public string DestinationName { get; set; }
        }
            var animalNameDict = new Dictionary<string, ElementName>
                {
                    {
                        "cow",
                        new ElementName
                            {
                                AccountName = "Farm Animals",
                                CampaignName = "Quadrupeds",
                                DocumentName = "Milk Givers",
                                DestinationName = "Milking line"
                            }
                    }
                };
            ElementName elem = null;
            animalNameDict.TryGetValue("cow", out elem);
            var item = animalNameDict.FirstOrDefault(x => x.Key == "cow");
