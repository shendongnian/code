      string[] names = Enum.GetNames(typeof(Cars));
      Cars[] values = (Cars[])Enum.GetValues(typeof(Cars));
      int start = names.ToList().IndexOf("Opel");
      int end = names.ToList().IndexOf("Citroen") + 1;
      for (int i = start; i < end; i++)
      {
          Console.WriteLine(names[i] + ' ' + values[i]);
      }
