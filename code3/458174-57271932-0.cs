        solution :
    
    
     public Response Get(string jsonData)
                {
                    var json = JsonConvert.DeserializeObject<modelname>(jsonData);
                    var data = StoredProcedure.procedureName(json.Parameter, json.Parameter, json.Parameter, json.Parameter);
                    return data;
                }
    
    
    
    
    model:
     public class modelname
        {
            public long parameter{ get; set; }
            public int parameter{ get; set; }
            public int parameter{ get; set; }
            public string parameter{ get; set; }
        }
