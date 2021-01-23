    List<int> list = new List<int>() {1 , 2};
    string json = JsonConvert.SerializeObject(
                      list.Select(x => new{
                          id = x.ToString(),
                          title = "title " + x.ToString(),
                          data = Enumerable.Range(3,2).Select(i=> new {column1=i,column2=i*i})
                        })
                      , Newtonsoft.Json.Formatting.Indented
                    );
