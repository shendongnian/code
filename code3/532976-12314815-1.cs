    public void Audit(MongoStorableObject oldVersion, MongoStorableObject newVersion)
        {
            if(oldVersion.GetType() != newVersion.GetType())
            {
                throw new ArgumentException("Can't Audit versions of different Types");
            }
            foreach(var i in oldVersion.GetType().GetProperties())
            {
                //The statement in here is not valid, how can I achieve look up of a particular attribute
                 if (i.GetCustomAttributes().Any(x=> x is MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute)) continue;
                //else do some actual auditing work
            }
        }
