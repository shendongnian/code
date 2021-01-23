    var values = new List<object>();
    foreach (dynamic item it myList) {
      try {
        values.Add(item.SomeProperty);
      } catch { 
        // Ignore missing SomeProperty values
      }
    }
