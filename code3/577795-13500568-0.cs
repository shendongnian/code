    var dic = new Dictionary<string, string>();
          dic.Add("1", "Introduction");
          dic.Add("1.1", "General");
          dic.Add("1.1.1", "Scope");
          dic.Add("1.2", "Expectations");
          dic.Add("2", "Background");
          dic.Add("2.1", "Early Development");
    
          foreach (var kvp in dic)
          {
            string item = String.Empty;
    
            int length = kvp.Key.Length - 2;
            while (length > 0)
            {
              var parent = dic[kvp.Key.Substring(0, length)];
              if (!String.IsNullOrEmpty(item))
                item = String.Format("{0} - {1}", parent, item);
              else
                item = parent;
              length -= 2;
            }
            if (!String.IsNullOrEmpty(item))
              item = String.Format("{0} - {1}", item, kvp.Value);
            else
              item = kvp.Value;
            Console.WriteLine(item);
          }
