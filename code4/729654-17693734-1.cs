    var resultCol = new List<string>();
    
    col1.ToList().Foreach(item => {
        if(!col2.Contains(item))
            resultCol.Add(item);
    });
