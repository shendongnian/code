    static void Main(string[] args)
        {
            using (var ctx = new HKDBEntities())
            {
               int wordId=2;
              // This will get the first Addresses which have a `Words` with `WordId`==2
              var selectedWords = ctx.Addresses.First(e=>e.Words.WordId==wordId); 
              //If you want to get to selectedWords the `Words` entity and delete it you should use:
              selectedWords = cts.Words.First(e=>e.WordId == wordId);
    
              ctx.Words.Remove(selectedWords);
              ctx.SaveChanges();
            }
        }
