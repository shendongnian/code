    bool IsInsertionError(string expected, string actual) {
        // Maybe look at all of the chars in expected, to see if all of them
        // are there in actual, in the correct order, but there's an additional one
    }
    bool IsDeletionError(string expected, string actual) {
        // Do the reverse of IsInsertionError - see if all the letters
        // of actual are in expected, in the correct order,
        // but there's an additional one
    }
    bool IsTransposition(string expected, string actual) {
        // This one might be a little tricker - maybe loop through all the chars,
        // and if expected[i] != actual[i], check to see if 
        // expected[i+1] = actual[i] and actual[i-1]=expected[i]
        // or something like that
    }
