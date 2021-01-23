    string json = JsonConvert.SerializeObject(
            new
            {
                pois = new object[] 
                {
                    new{
                        poi=new {
                            title="Test title",
                            latitude="-2.4857856",
                            longitude="54.585656"
                        }
                    },
                    new{
                        poi=new {
                            title="Halfords",
                            latitude="-2.4857856",
                            longitude="53.5867856"
                        }
                    }
                }
                    
            }
            , Newtonsoft.Json.Formatting.Indented
        );
    Console.WriteLine(json);
