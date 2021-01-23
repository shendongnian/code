    public struct EntityGroupKey
    {
      public int ID {get;set;}
      public string Name {get;set;}
    }
    
    public class EntityGrouper
    {
      public Func<Entity, EntityGroupKey> KeySelector {get;set;}
      public Func<EntityGroupKey, TreeViewItem> ResultSelector {get;set;}
      public EntityGrouper NextGrouping {get;set;} //null indicates leaf level
    
      public List<TreeViewItem> GetItems(IEnumerable<Entity> source)
      {
        var query =
          from x in source
          group x by KeySelector(x) into g
          let subItems = NextGrouping == null ?
            new List<TreeViewItem>() :
            NextGrouping.GetItems(g)
          select new { Item = ResultSelector(g.Key), SubItems = subItems };
    
        List<TreeViewItem> result = new List<TreeViewItem>();
        foreach(var queryResult in query)
        {
              // wire up the subitems
          queryResult.Item.SubItems = queryResult.SubItems 
          result.Add(queryResult.Item);
        }
        return result;
      }
    
    }
