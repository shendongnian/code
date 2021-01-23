       public static void ArrangeColumns(ListView listView, params String [] order) {
          listView.BeginUpdate();
          try { 
            for (int i = 0; i < order.Length; ++i) {
              Boolean found = false;
    
              for (int j = 0; j < listView.Columns.Count; ++j) {
                if (String.Equals(listView.Columns[j].Text, order[i], StringComparison.Ordinal)) {
                  listView.Columns[j].DisplayIndex = i;
    
                  found = true;
    
                  break;
                }
              }
    
              if (!found) 
                throw new ArgumentException("Column " + order[i] + " is not found.", "order"); 
            }
          } 
          finally {
            listView.EndUpdate();
          }
        }
    
      ...
    
      ArrangeColumns(myListView, "name", "job", "phone", "school", "age");
