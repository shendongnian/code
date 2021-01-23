    public static SortedList<int, T> MultiIntersect<T>(params SortedList<int, T>[] lists) {
      SortedList<int, T> result = new SortedList<int, T>();
      int[] index = new int[lists.Length];
      bool cont;
      do {
        int list = 0;
        int value = lists[list].Keys[index[list]];
        while (list < lists.Length) {
          while (index[list] < lists[list].Count && lists[list].Keys[index[list]] < value) index[list]++;
          if (index[list] == lists[list].Count) {
            return result;
          } else if (lists[list].Keys[index[list]] > value) {
            value = lists[list].Keys[index[list]];
            list = 0;
          } else {
            list++;
          }
        }
        result.Add(value, lists[0].Values[index[0]]);
        cont = true;
        for (var i = 0; i < index.Length; i++) {
          index[i]++;
          cont &= index[i] < lists[i].Count;
        }
      } while(cont);
      return result;
    }
