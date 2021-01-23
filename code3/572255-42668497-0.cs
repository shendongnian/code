    public static bool IsConsecutive(this List<Int32> value){
        return value.OrderByDescending(c => c)
                    .Select(c => c.ToString())
                    .Aggregate((current, item) => 
                                (item.ToInt() - current.ToInt() == -1) ? item : ""
                                )
                    .Any();
    }
