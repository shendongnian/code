    var lines1 = text1.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Where(l => l.Trim().Length > 0); 
    var lines2 = text2.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Where(l => l.Trim().Length > 0);
 
