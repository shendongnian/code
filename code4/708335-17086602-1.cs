    public class ItemTree
    {
      //simple DFS walk of the tree
      public IEnumerable<ItemTree> GetChildren()
      {
         //no items, stop execution
         if ((item == null) || (item.Count == 0))
           yield break;
         foreach (var child in item)
         {
            //return the child first
            yield return child;
            //no way to yield return a collection
            foreach (var grandchild in child.GetChildren())
            {
               yield return grandchild;
            }
         }
      }
    }
