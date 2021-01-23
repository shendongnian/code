        //output all
        foreach (var item1 in list.Flatten())
        {
          item1.Output();
        }
        Console.WriteLine();
       
        //output filtered items
        var filtered_list = list
           .Flatten()
           .Where(item1 => item1.MyClasses2
              .Any(item2 => item2.MyClasses3
                .Any(item3 => item3.Property1 == true)
              )
           )
          .ToArray();
        foreach (var item1 in filtered_list)
        {
          item1.Output();
        }
