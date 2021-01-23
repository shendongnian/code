    var Input = 42;
    var Product = 1;
    var Result = 0;
    // Iteration - step 1: 
    Result = Input % 10; // = 2
    Input -= Result;
    Product *= Result;
    // Iteration - step 2:
    Result = Input % 100 / 10; // = 4
    Input -= Result;
    Product *= Result;
