    var list = new List<string>(textBox1.Lines);
    
    for (int i = 0; i < list.Count; ++i)
    {
      list[i] = "A" + list[i] + "B";
    }
    
    textBox1.Lines = list.ToArray();
