    var sourceToken = new System.Threading.CancellationTokenSource();
    
    var t2 = System.Threading.Tasks.Task.Run(() =>
      {
        var token = sourceToken.Token;
        return context.myTable.Where(s => s.Price == "Right").Select(i => i.ItemName).ToListAsync(token);
      }
      , sourceToken.Token
    );
