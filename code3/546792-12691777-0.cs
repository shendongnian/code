    int param = 10;
    // Define min and max array indices for readability.
    public const int min = 0;
    public const int max = 1;
    int[,] myValues = {
        { 1, 50 }, 
        { 2, 3  },
        { 5, 60 }};
    var matches = 
        from  item in myValues
        where param <= item[min] && 
              param >= item[max];
