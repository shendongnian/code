    // static fixpoint operator (highly reusable)
    public static Action<T> ActionFix<T>(Func<Action<T>, Action<T>> f)
    {
        return t => f(ActionFix(f))(t);
    }
    // your recursive ordering
    foreach (var parentContent in contentList)
    {
      ActionFix<Content>(
         actionContent => 
               content => 
                    {
                     // ordering on the subContent of the node
                     content.SubContent = content.SubContent.OrderBy(sc => sc.SortLevel).ToList();  
                     // recursive ordering on each element on the subContent
                     content.SubContent.ToList().ForEach(actionContent);
                    })
      (parentContent);
    }
