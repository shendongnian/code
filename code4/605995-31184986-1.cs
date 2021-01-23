      public string TestProperty {get; set;}
      public Dictionary<int, Func<string>> dictionary;
      Constructor()
      {
        dictionary = new Dictionary<int, Func<string>>
        {
            {1, ()=>TestProperty }
        }
      }
