    static void Main(string[] args)
        {
            using (var ctx = new HKDBEntities())
            {
               int wordId=2;
              var selectedWords = ctx.Addresses.First(e=>e.word==wordId); 
              //If you want to get to selectedWords the `Words` entity and delete it you should use:
              selectedWords = cts.Words.First(e=>e.WordId == wordId);
    
              ctx.Words.Remove(selectedWords);
              ctx.SaveChanges();
            }
        }
