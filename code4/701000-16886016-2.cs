    var count = datakoppling.surveyAnswers.Count();
    var midPoint = count / 2;
    double medianValue;
    if (count % 2 = 0)
    {
        medianValue = datakoppling.surveyAnswers
                                  .OrderBy(s => s.Value)
                                  .Take(midPoint + 1)
                                  .Skip(midPoint - 1)
                                  .Average(s => s.Value);
    }
    else
    {
        medianValue = datakoppling.surveyAnswers
                                  .OrderBy(s => s.Value)
                                  .Select(s => s.Value)
                                  .Take(midPoint + 1)
                                  .Last();
    }
