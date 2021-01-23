      // Your dictionary
      Dictionary<String, String> dict = new Dictionary<string, string>() {
        {"Apartment1", "Free"},
        {"Apartment2", "Taken"}
      };
    
      // Message Creating 
      StringBuilder S = new StringBuilder();
    
      foreach (var pair in dict) {
        if (S.Length > 0)
          S.AppendLine();
    
        S.AppendFormat("{0} - {1}", pair.Key, pair.Value);
      }
    
      // Showing the message
      MessageBox.Show(S.ToString());
