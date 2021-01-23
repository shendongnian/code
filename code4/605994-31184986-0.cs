      public string TestProperty {get; set;}
      public dictionary<int, Func<string>>
      Constructor()
      {
        dictionary = new Dictionary<int, Func<string>>
        {
            {1, ()=>TestProperty }
        }
      }
