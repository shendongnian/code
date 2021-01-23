    public List<AnObjectModel> GetObjectFromDB(TheParameters)
    {
       using MyDataContext
       {
         return (....select new AnObjectModel()...).ToList();
       }
    }
