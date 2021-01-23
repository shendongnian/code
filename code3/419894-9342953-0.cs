    public class CsvInserts
    {
       private IList<string> InsertsProgress {
            get {
                 if (HttpContext.Current.Session["CsvInserts.Inserts"] == null )
                    HttpContext.Current.Session["CsvInserts.Inserts"]  = new List<string>();
                 return (IList<string>)HttpContext.Current.Session["CsvInserts.Inserts"];
            }
       }
       public IList<string> GetInsertsProgress() {
             return InsertsProgress;
       }
       public void InsertFile(string[] lines) {
             foreach ( var line in lines)
                  {
                        var row = DataAccess.CsvInserts.Insert(line); // code to insert the line
                        InsertsProgress.Add(row.GetRelevantInfoForUser()); // successfully inserted or not and which line was inserted
                  }
       }
    }
