    public static class Extensions
    {
        public static double FindSmallestGreaterThan(this SortedList<double,double> list, double value)
        {
           foreach(double d in list.Keys)
           {
               if(d > value) return d;
           }
           throw new IndexOutOfRangeException("No values in the list greater than " + value.ToString());
        }
    }
