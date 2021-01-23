    string[] items = value.Split(",");
    foreach (string item in items) {
      if (item.Contains("-")) {
        string[] parts = item.Split("-");
        int min = Int32.Parse(parts[0]);
        int max = Int32.Parse(parts[1]);
        for (int i = min; i <= max; i++) {
          // add the value in i to the data
        }
      } else {
        // add the value in item to the data
      }
    }
