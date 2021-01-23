    var data = new List<Customer>();
                
    data.ToDictionary(item => item.ID, 
                        item => new Dictionary<string, bool>
                        {
                            {item.City,item.DidLive}
                        });
