    public static Dictionary<string,int> CountCharacters(string input)
    {
         var counts = new Dictionary<char,int>(StringComparer.OrdinalIgnoreCase);
         foreach (var c in input)
         {
              int count = 0;
              if (counts.ContainsKey(c))
              {
                  count = counts[c];
              }
              counts[c] = counts + 1;
         }
         return counts;
    }
