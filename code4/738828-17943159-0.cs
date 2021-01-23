    while ((linevalue = filereader.ReadLine()) != null)
        {
              items.Add(linevalue.Split('\t').Last());
        }
        filereader.Close();
        items.OrderBy(i => DateTime.Parse(i));
        foreach(var item in items)
        {
            Console.WriteLine(item);
        }
