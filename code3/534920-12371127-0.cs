    class DictionaryNode {
      public int? Next { get; set; }
      public string Value { get; set; }
    }
    
    
    // Inside the appropriate class
    int? lastKey = null;
    void AddItem(int key, string value) {
      mylist.Add(key, new DictionaryNode { Next = null, Value = value });
      if (lastKey.HasValue) {
        mylist[lastKey].Next = key;
      }
      lastKey = key;
    }
