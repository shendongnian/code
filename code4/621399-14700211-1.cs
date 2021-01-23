    object obj = new DateTime();
    int test = ((DateTime)obj).Second;   // Have to cast here, as object does not contain Second
    DateTime obj2 = new DateTime();
    int test2 = obj2.Second; // It is a DateTime so all good
    var obj3 = new DateTime(); // Type is infered by right hand side assignment
    int test3 = obj3.Second; // It is a DateTime so all good
