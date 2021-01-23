    foreach (Person p in queryAllPeople)
    {
      using (StreamWriter writer = new StreamWriter("people.txt", true))
      {
    
         writer.WriteLine(p);
    
      }
      Console.WriteLine(p);
    }
