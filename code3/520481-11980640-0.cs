    var list = input.Split(':');
    var outputs = new List<string>();
    for (int index = 0; index < list.Count(); index++)
    {
         if (index % 4 == 3)
             outputs.Add(list.ElementAt(index));
    }
