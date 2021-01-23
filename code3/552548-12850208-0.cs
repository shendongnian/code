    var tuple = new Tuple<Question, Levels[]>(question, 
        new [] { Levels.Easy, Levels.Medium, Levels.Hard});
    
    var questionLevels = tuple.Item2.ToLookup(level => tuple.Item1);
    // questionLevels contains:
    // question, Levels.Easy
    // question, Levels.Medium
    // question, Levels.Hard
