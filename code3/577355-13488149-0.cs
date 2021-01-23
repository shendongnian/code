    for (int i = 0; i < list.Count; i += 2)
    {
       SW.Write(list[i]);
       SW.Write("\t");
       SW.WriteLine(list[i+1]);
    }
