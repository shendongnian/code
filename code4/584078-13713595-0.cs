    var dict = new Dictionary<int, HashSet<List<int>>>();
    
    foreach (List<int> list2 in two) {
       foreach (int i in list2) {
          if(dict.ContainsKey(i) == FALSE) {
             //create empty HashSet dict[i]
             dict.Add(i, new HashSet<List<int>>());
          }
          //add reference to list2 to the HashSet dict[i]
          dict[i].Add(list2); 
       }
    }
    
    foreach (List<int> list1 in one) {
       HashSet<List<int>> listsInTwoContainingList1 = null;
       foreach (int i in list1) {
          if (listsInTwoContainingList1 == null) {
             listsInTwoContainingList1 = new HashSet<List<int>>(dict[i]);
          } else {
             listsInTwoContainingList1.IntersectWith(dict[i]);
          }
          if(listsInTwoContainingList1.Count == 0) {   //optimization :p
             break;
          }
       }
       foreach (List<int> list2 in listsInTwoContainingList1) {
          //list2 contains list1
          //do something
       }   
    }
