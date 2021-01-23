    List<string> tb1lines = textbox1.Lines.ToList();
    List<string> tb2lines = textbox2.Lines.ToList();
    List<string> newtb2lines = new List<string>();
                
    foreach (string s in tb1lines)
        newtb2lines.Add(tb2lines.Where(l => l.StartsWith(s)).ToList()[0]);
    
    textbox2.Lines = newtb2lines.ToArray();
