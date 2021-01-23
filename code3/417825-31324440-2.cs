    // declare and define initial variables.
    int x = 0;
    int y = 100;
    // set the value of 'x'    
    x = 44;
    
    // Results in 0 as the whole number 44 over the whole number 100 is a 
    // fraction less than 1, and thus is 0.
    Console.WriteLine( (x / y).ToString() );
    
    // Results in 0 as the whole number 44 over the whole number 100 is a 
    // fraction less than 1, and thus is 0. The conversion to double happens 
    // after the calculation has been completed, so technically this results
    // in 0.0
    Console.WriteLine( ((double)(x / y)).ToString() );
    
    // Results in 0.44 as the variables are cast prior to calculating
    // into double which allows for fractions less than 1.
    Console.WriteLine( ((double)x / (double)y).ToString() );
