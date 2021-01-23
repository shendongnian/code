    public Class IndexBuilder<T> where T : A
    {
       List<string> Go(T obj)
       {
          string aPt=obj.GetAccessPoint();
          string pMap=obj.GetPriorityMap();
       }
    }
