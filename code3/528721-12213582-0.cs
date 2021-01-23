        public static void Remove(List<ObjectId> objectIds)
        {
            var linqQuery = from n in ObjectMongoCollection.AsQueryable<Notification>() where n.NotificationId.In(objectIds) select n;
            var mongoQuery = ((MongoQueryable<Notification>)linqQuery).GetMongoQuery();       
            ObjectMongoCollection.Remove(mongoQuery);
        }
