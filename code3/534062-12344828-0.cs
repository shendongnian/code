    public static class FictionBookExtensions
    {
        public static void Delete(IEnumerable<YourFictionBookClass> fictionBooks)
        {
            foreach (var fictionBook in fictionBooks)
            {
                db.DeleteObject(fictionBook);
            }
        }
    }
