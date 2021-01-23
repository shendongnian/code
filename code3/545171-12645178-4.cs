    //
    // 1. Create two dimensional array
    //
    const int  dim = 1000;
    double[,]  array = new double[dim,dim];
    
    Random ran = new Random();
    for(int r = 0; r < dim; r++)
    {
        for(int c = 0; c < dim; c++)
        {
            array[r,c] = (ran.Next(dim)); // fill it with random numbers.
        }
    }
    
    // 2. Create ArrayDataView class in which 
    // constructor you pass the array 
    // and assign it to DataSource property of DataGrid. 
    
     dataGrid1.DataSource = new ArrayDataView(array);
