    public static double FindSmallestGreaterThan(this SortedList<double,double> list, double value)
    {
       foreach(double d in list.Keys)
       {
           if(d > value) return d;
       }
    }
    
