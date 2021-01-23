    Dictionary<int, List<Country>> countriesDictionary = countries.GroupBy(g => g.CountryCode).ToDictionary(k => k.Key, k => k.ToList());
    
    foreach (int key in countriesDictionary.Keys)
    {
          Console.WriteLine("****Countries with code {0}****",key);
          int count = 0;
          while (count < countriesDictionary[key].Count)
          {
                Console.WriteLine(countriesDictionary[key][count].CountryName);
                count++;
          }
          Console.WriteLine();
    }
    Console.ReadLine();
