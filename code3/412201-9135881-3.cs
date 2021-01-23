        var request = new MainRequest
        {
            Parameters = new Request
            {
                RequestSize = new RequestSize
                {
                    Count = "2",
                    Value = "5",
                },
                Batches = new Batch[]
                {
                    new Batch 
                    { 
                        Fields = new Field[] 
                        { 
                            new Field { Name = "AAA", Value = "111"},
                            new Field { Name = "BBB", Value = "222"},
                            new Field { Name = "CCC", Value = "333"},
                        }
                    },
                    new Batch 
                    { 
                        Fields = new Field[] 
                        { 
                            new Field { Name = "DDD", Value = "444"},
                            new Field { Name = "EEE", Value = "555"},
                        }
                    }
                }
            }
        };
