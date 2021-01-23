    public IEnumerable<T> GetElements()
    {      
       foreach(T t in listOfT)
       {
           // do some work
           yield return t;
           //code will continue here on next iteration       
       }
    }
