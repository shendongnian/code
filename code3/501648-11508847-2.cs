    bool FirstCheck(int?[][] theArray)
    {
        int size = (from arrays in theArray select arrays.GetUpperBound(0)).Max();
        var check = from arrays in theArray
                    where theArray.All(sub => sub.GetUpperBound(0) == size)
                    select arrays;
        return size + 1 == check.Count<int?[]>();
    }
    bool SecondCheck(int?[][] theArray)
    {
        int size = (from arrays in theArray select arrays.GetUpperBound(0)).Max();
        var check = from arrays in
                        (from subs in theArray
                         where theArray.All(sub => sub.All(value => value != null))
                         select subs)
                    where arrays.GetUpperBound(0) == size
                    select arrays;
        return size + 1 == check.Count<int?[]>();
    }
    bool ThirdCheck(int?[][] theArray)
    {
       int size = (from arrays in theArray select arrays.GetUpperBound(0)).Max();
       var check = from arrays in
                        (from subs in theArray
                         where theArray.All(sub => sub[0] != null)
                        select subs)
                    where arrays.GetUpperBound(0) == size
                    select arrays;
       return size + 1 == check.Count<int?[]>();
    }
