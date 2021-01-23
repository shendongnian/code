    List<string> test = new List<string>();
    test.Add("Lemon");
    test.Add("Orange");
    test.Add("Pepper");
    test.Add("Tomato");
    string str = "Today, I ate a tomato and an orange.";
    foreach (string s in test)
    {
          // Or use StringComparison.OrdinalIgnoreCase when cultures are of no issue.
          if (str.IndexOf(s, StringComparison.CurrentCultureIgnoreCase) > -1)
          {
              Console.WriteLine("Sentence contains word: " + s);
          }
    }
    Console.Read();
