    List<string> test = new List<string>();
    test.Add("Lemon");
    test.Add("Orange");
    test.Add("Pepper");
    test.Add("Tomato");
    string str = "Today, I ate a tomato and an orange.";
    foreach (string s in test)
    {
          if (str.ToLower().IndexOf(s.ToLower()) > 0)
          {
              Console.WriteLine("Sentence contains word: " + s);
          }
    }
    Console.Read();
