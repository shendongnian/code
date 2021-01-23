    var query = (from table1 in dtSzotar
                where errorList.Any(word => table1.angol.Equals(word)) ||
                      errorList.Any(word=> table1.magyar.Equals(word))
                select new QueryObject
                {
                    Lesson = table1.lesson,
                    English = table1.angol,
                    Hungarian = table1.magyar,
                    Answer = "",
                }).ToList();
    // now query is a List<QueryObject>
    foreach (QueryObject row in query)
    {
          String tmp;
          ((App)Application.Current).Answer.TryGetValue(row.English, out tmp); 
          row.Answer = tmp;
    }
    
    dgInCorrect.ItemsSource = query;
