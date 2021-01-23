    public static IEnumerable<String> Split(this String me, int SIZE) {      
      if (me.Length > SIZE) {
        var head = me.Substring(0,SIZE);
        var tail = me.Substring(SIZE,me.Length-SIZE);
        yield return head;        
        foreach (var item in tail.Split(SIZE)) {
          yield return item; 
        }
      } else { 
        yield return me;
      }
    }
