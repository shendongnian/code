     public void Update(Customer cus)
        {
            if (cus != null)
            {
                MongoDB.Driver.MongoClient client = new MongoClient(_connectionString);
                MongoDatabase db = client.GetServer().GetDatabase(_dbName);
                db.GetCollection(_dbName).Save(cus);
            }
    
        }
