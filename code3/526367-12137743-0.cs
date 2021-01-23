      var testAnswers = new[] { 1, 2, 3 };
      var inputAnswers = new[] { 3, 2, 1 };
      var commonAnswers = testAnswers
                .Select((x, index) => Tuple.Create(x, index))
                .Intersect(inputAnswers.Select((y, index) => Tuple.Create(y, index)));
      Console.WriteLine("Common answers: {0}", commonAnswers.Count());
      Console.ReadKey();
