    void Do(MongoCollection col, IQueryable iq)
    {
            // Json Mongo Query
            var imq = (iq as MongoQueryable<Blob>).GetMongoQuery();
            Console.WriteLine(imq.ToString());
            // you could also just do;
            // var cursor = col.FindAs(typeof(Blob), imq);
            var cursor = MongoCursor.Create(typeof(Blob), col, imq, ReadPreference.Nearest);
            var explainDoc = cursor.Explain();
            Console.WriteLine(explainDoc);
        }//Do()
