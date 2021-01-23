    if(PenultimateCondition(mylist))
    {
        //do something
    }
    public static bool PenultimateCondition(List<Datetime> list)
    {
         return list[list.Count - 1] == list.[list.Count - 2];
    }
