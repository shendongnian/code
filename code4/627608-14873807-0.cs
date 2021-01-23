    static void Main(string[] args)
        {
            using (var ctx = new HKDBEntities())
            {
               int wordId=2;
              var selectedWords = (from o in ctx.Addresses 
                                    where o.word== wordId
                                    select o).FirstOrDefault(); 
    
              ctx.Words.Remove(selectedWords);
              ctx.SaveChanges();
            }
        }
