    [HttpPost]
    public JsonResult SaveQuestions(Question[] questions)
    {
      foreach (var q in questions)
      {
        //do regular question processing stuff
        //20 lines later
        IEnumerable<IGrouping<string, QuestionExtendedProp>> ExtendedPropGroups = q.TemporaryExtendedProperties.GroupBy(x => x.DictionaryKeyValue);
        foreach (IGrouping<string, QuestionExtendedProp> group in ExtendedPropGroups)
        {
          string groupKey = group.Key;
          foreach (var qexp in group)
          {
            //do things here
          }
        }
      }
      //rest of the stuff now that I've processed my extended properties...properly
      return Utility.SaveQuestions(questions);
    }
