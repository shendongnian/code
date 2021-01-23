    if(myclass.PenultimateCondition(mylist))
    {
        //do something
    }
    public class myclass
    {
        public static bool PenultimateCondition(List<Datetime> list)
        {
             return list[list.Count - 1] == list.[list.Count - 2];
        }
    }
