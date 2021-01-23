    var ListOfNumbers = new List<int> { 1, 2, 3 ,4 }
    var total = 0;
    foreach (var c in ListOfNumbers)
    {
        total = c;
    }
    Console.WriteLine(total.ToString());
would output 4
    var ListOfNumbers = new List<int> { 1, 2, 3 ,4 }
    var total = 0;
    foreach (var c in ListOfNumbers)
    {
        total += c;
    }
    Console.WriteLine(total.ToString());
would output 10
