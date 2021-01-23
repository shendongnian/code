    int parsedMonth; // This will get set if myColMonth is a valid integer
    if (int.TryParse(myColMonth, out parsedMonth) && parsedMonth <= myMostRecentActualMonth)
    {
       // ...
    }
