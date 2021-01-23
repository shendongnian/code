    int inputCount = ...;
    var paramExpressions = GenerateArray(inputCount, i => Expression.Parameter(typeof(byte[]), "input" + i);
    
    var summands = GenerateArray(inputCount, i => Expression.Mul(/* inputA[i] HERE */, Expression.Constant(multipliers[i]));
    
    var sum = summands.Aggregate((a,b) => Expression.Add(a,b));
    
    var assignment = /* assign sum to pixelmap[i] here */;
    
    var loop = /* build a loop. ask a new question to find out how to do this, or use google */
    
    var lambda = Expression.Lambda(paramExpressions, loop);
    
    var delegate = lambda.Compile();
    
    //you are done compiling. now invoke:
    
    delegate.DynamicInvoke(arrayOfInputs); //send an object of type byte[][] into the lambda
