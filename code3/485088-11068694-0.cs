    public class PList
    {
      public IEnumerable<PListItem> Where(PList source, Func<PListItem, bool> predicate)
      {
        foreach (var item in this.items)
        {
          if (predicate(item)) 
          {
            yield return item;
          }
        }
      }
    }
