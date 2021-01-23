    string str= "ahmad,ehsan,mohmmad,sss"; 
    var subStrings = str.Split(',');
    foreach (var s in subStrings)
    { 
        Console.WriteLine(s);
    }
    var newString = str.Replace(","," ");
    Console.WriteLine(newString);
