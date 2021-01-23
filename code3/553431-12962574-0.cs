        public IEnumerable<IDictionary> Get()
        {
            using (var mongo = new Mongo())
            {
                var collection = mongo.GetCollection<BsonDocument>("Report");
                var cursor = collection.FindAll();
                cursor.SetFields(_summaryFields); 
                int i = 0;
                foreach (var doc in cursor)
                {
                    i++;
                    yield return doc.ToDictionary();
                }
            }        
        }
