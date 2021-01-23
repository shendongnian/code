    private static Stack<T> CreateShuffledDeck<T>(IEnumerable<T> values)
    {
      var rand = new Random();
      var list = new List<T>(values);
      var stack = new Stack<T>();
      
      while(list.Count > 0)
      {
        // Get the next item at random.
        var index = rand.Next(0, list.Count);
        var item = list[index];
        // Remove the item from the list and push it to the top of the deck.
        list.RemoveAt(index);
        stack.Push(item);
      }
      
      return stack;
    }
