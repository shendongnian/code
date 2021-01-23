    public static class StringBuilderSearching
    {
      public static bool Contains(this StringBuilder haystack, string needle)
      {
        return haystack.IndexOf(needle) != -1;
      }
      public static int IndexOf(this StringBuilder haystack, string needle)
      {
        if(haystack == null || needle == null)
          throw new ArgumentNullException();
        if(needle.Length == 0)
          return 0;//empty strings are everywhere!
        if(needle.Length == 1)//can't beat just spinning through for it
        {
          char c = needle[0];
          for(int idx = 0; idx != haystack.Length; ++idx)
            if(haystack[idx] == c)
              return idx;
          return -1;
        }
        int m = 0;
        int i = 0;
        int[] T = KMPTable(needle);
        while(m < haystack.Length - 1)
        {
          if(needle[i] == haystack[m + i])
          {
            if(i == needle.Length - 1)
              return m == needle.Length ? -1 : m;//match -1 = failure to find conventional in .NET
            ++i;
          }
          else
          {
            m = m + i - T[i];
            i = T[i] > -1 ? T[i] : 0;
          }
        }
        return -1;
      }      
      private static int[] KMPTable(string sought)
      {
        int[] table = new int[sought.Length];
        int pos = 2;
        int cnd = 0;
        table[0] = -1;
        table[1] = 0;
        while(pos < table.Length)
          if(sought[pos - 1] == sought[cnd])
            table[pos++] = ++cnd;
          else if(cnd > 0)
            cnd = table[cnd];
          else
            table[pos++] = 0;
        return table;
      }
    }
