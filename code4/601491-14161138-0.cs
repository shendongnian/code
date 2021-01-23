    private void Save(object)
    {
       mongoCollection.Save(object);
       try
       {
          someotherRelationaldb.Save(object);
       }
       catch
       {
          mongoCollection.Remove(Query.EQ("_id", object.Id));
       }
    }
