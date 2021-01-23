    var result = question.GroupBy(x=>new{x.QuestionNo , x.ActivityID})
    .Select(g=> new {QuestionNo= g.Key.QuestionNo, 
                     ActivityID= g.Key.ActivityID,
                     joined = string.Join(" ", g.Select(i=>i.Question+ "[" + i.Answer +"]"))})
    .Take(30);
