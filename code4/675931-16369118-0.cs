      StackyClient client = new StackyClient("2.1", Sites.StackOverflow,
            new UrlClient(), new JsonProtocol());
      //var o = new QuestionOptions();
      //o.FromDate = DateTime.Now.AddMinutes(-10.0);
      //o.ToDate = DateTime.Now;
      //o.IncludeAnswers = false;
      //o.IncludeBody = false;
      //o.IncludeComments = false;
      //o.SortBy = QuestionSort.Creation;
      //o.SortDirection = SortDirection.Descending;
      QuestionSort sort = QuestionSort.Creation;
      SortDirection sortDir = SortDirection.Descending;
      int page = 1;
      int pageSize = 100;
      DateTime fromDate = DateTime.Now.AddMinutes(-10.0);
      DateTime toDate = DateTime.Now;
      IPagedList<Question> l = client.GetQuestions(sort, sortDir, page, pageSize, fromDate, toDate);
      foreach (var question in l)
      {
        Console.WriteLine(question.Title);
      }
 
 
