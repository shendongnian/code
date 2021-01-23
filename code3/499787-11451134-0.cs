    using(DBEntities dbConnection = new DBEntities())
    {
        foreach(MyObjectCreatedFromTheLine entity in ListOfMyObjectCreatedFromTheLine)
        {
            dbConnection.My_Table.AddObject(MyObjectCreatedFromTheLine);
        }
        dbConnection.SaveChanges();
    }
