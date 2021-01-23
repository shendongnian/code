    string myString = "WordOne \"Word Two\"";
    var result = myString.Split('"')
                         .Select((element, index) => index % 2 == 0  // If even index
                                               ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                                               : new string[] { element })  // Keep the entire item
                         .SelectMany(element => element).ToList();
    Console.WriteLine(result[0]);
    Console.WriteLine(result[1]);
    Console.ReadKey();
