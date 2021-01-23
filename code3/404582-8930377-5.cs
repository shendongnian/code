    string someResult;
    string errorMessage;
    if (!TryXXX("some parameter", out someResult, out errorMessage))
    {
        // an error occurred => use errorMessage to get more details
    }
    else
    {
        // everything went fine => use the results here
    }
