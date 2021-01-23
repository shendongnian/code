    var newOne = arrText.OrderByDescending(int.Parse).ToArray();
    
    foreach (var s in newOne)
    {
          txtOutput.AppendText(s);
    }
