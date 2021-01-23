            List<string> names = new List<string>() {"Mike","Joe","Jane"};
            Dictionary<string, int> ids = new Dictionary<string, int>()
                                              {
                                                  {"Mike",1},
                                                  {"Joe",2},
                                                  {"Jane",3},
                                              };
            // ["Mike","Joe","Jane"]
            string nameJson = Newtonsoft.Json.JsonConvert.SerializeObject(names);
            //{"Mike":1,"Joe":2,"Jane":3}
            string idsJSon = Newtonsoft.Json.JsonConvert.SerializeObject(ids);
