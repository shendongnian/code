    public string UpdateData()
            {               
                string data = string.Empty;
                string param= "{$set: { name:'Developerrr New' } }";
                string filter= "{ 'name' : 'Developerrr '}";
                try
                {  
                   //******get connections values from web.config file*****
                    var connectionString = ConfigurationManager.AppSettings["connectionString"];
                    var databseName = ConfigurationManager.AppSettings["database"];
                    var tableName = ConfigurationManager.AppSettings["table"];
                    //******Connect to mongodb**********
                    var client = new MongoClient(connectionString);
                    var dataBases = client.GetDatabase(databseName);
                    var dataCollection = dataBases.GetCollection<BsonDocument>(tableName);       
                    //****** convert filter and updating value to BsonDocument*******
                    BsonDocument filterDoc = BsonDocument.Parse(filter);
                    BsonDocument document = BsonDocument.Parse(param);
    
                    //********Update value using UpdateOne method*****
                    dataCollection.UpdateOne(filterDoc, document);                   
                    data = "Success";
                }
                catch (Exception err)
                {
                    data = "Failed - " + err;
                }
                return data;    
            }
