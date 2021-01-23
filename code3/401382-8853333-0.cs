    public PropertyForDisplay
    {
        get
        {
           String[] array = OriginalProperty.Split('#');
           if(array.Length > 0)
               return array[0] ;
 
           return String.Empty;
        }
    }
