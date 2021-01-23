    int indexOfDash = id.IndexOf("-");
    
    var firstPart = id.TakeWhile(s => s != '-');
    var linqGender = firstPart.Take(1).ToArray()[0];  // string is L
    var linqProduct = String.Join("", firstPart.Skip(1).Take(indexOfDash-1)); // string is SHOE
    
    var secondPart = id.Skip(indexOfDash+1);
    var linqCategory = String.Join("", secondPart);  //string is UCT
