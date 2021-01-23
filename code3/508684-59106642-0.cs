    double[,] myArray = new double[x, y];
        
    if( parallel == true )
    {
        
        stopWatch.Start();
        System.Threading.Tasks.Parallel.For( 0, x, i =>
        {
          
            for( int j = 0; j < y; ++j )
            {
            
                myArray[i, j] = double.PositiveInfinity;  
            
            }
          
        });
        stopWatch.Stop();
      
        Print( "Elapsed milliseconds: {0}", stopWatch.ElapsedMilliseconds );
          
    }
        
    else
    {
        
        stopWatch.Start();
        for( int i = 0; i < x; ++i )
        {
          
            for( int j = 0; j < y; ++j )
            {
            
              myArray[i, j] = double.PositiveInfinity;  
            
            }
          
        }
        stopWatch.Stop();
      
        Print("Elapsed milliseconds: {0}", stopWatch.ElapsedMilliseconds);
          
    }
