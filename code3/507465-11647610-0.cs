    List<List<int>> idList = GetFullList(); //list contains 600 rows  
    var iterator = idList.Begin();
  
    int[] newItems = {1, 3, 5};  
    int count = 0;  
    int amountToAmend = 200;  
    foreach (var item in newItems)
    {
       iterator = iterator.AddItem(item);
       iterator = iterator.MoveForward(amountToAmend);
    }
    public struct NestedListIterator<T>
    {
      public NestedListIterator(List<List<T>> lists, int listIndex, int itemIndex)
      {
        this.lists = lists;
        this.ListIndex = listIndex;
        this.ItemIndex = itemIndex;
      }
      public readonly int ListIndex;
      public readonly int ItemIndex;
      public readonly List<List<T>> lists;
      public NestedListIterator<T> AddItem(T item)
      {
        var list = lists.ElementAtOrDefault(ListIndex);
        if (list == null || list.Count < ItemIndex)
          return this;//or throw new Exception(...)
        list.Insert(ItemIndex, item);
        return new NestedListIterator<T>(this.lists, this.ListIndex, this.ItemIndex + 1);
      }
      public NestedListIterator<T> MoveForward(List<List<T>> lists, int index)
      {
        //if (index < 0) throw new Exception(..)
        var listIndex = this.ListIndex;
        var itemIndex = this.ItemIndex + index;
        for (; ; )
        {
          var list = lists.ElementAtOrDefault(ListIndex);
          if (list == null)
            return new NestedListIterator<T>(lists, listIndex, itemIndex);//or throw new Exception(...)
          if (itemIndex <= list.Count)
            return new NestedListIterator<T>(lists, listIndex, itemIndex);
          itemIndex -= list.Count;
          listIndex++;
        }
      }
      public static int Compare(NestedListIterator<T> left, NestedListIterator<T> right)
      {
        var cmp = left.ListIndex.CompareTo(right.ListIndex);
        if (cmp != 0)
          return cmp;
        return left.ItemIndex.CompareTo(right.ItemIndex);
      }
      public static bool operator <(NestedListIterator<T> left, NestedListIterator<T> right)
      {
        return Compare(left, right) < 0;
      }
      public static bool operator >(NestedListIterator<T> left, NestedListIterator<T> right)
      {
        return Compare(left, right) > 0;
      }
    }
    public static class NestedListIteratorExtension
    {
      public static NestedListIterator<T> Begin<T>(this List<List<T>> lists)
      {
        return new NestedListIterator<T>(lists, 0, 0);
      }
      public static NestedListIterator<T> End<T>(this List<List<T>> lists)
      {
        return new NestedListIterator<T>(lists, lists.Count, 0);
      }
    }
