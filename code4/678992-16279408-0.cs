    var userInput = Console.ReadLine();
    Console.WriteLine(new string(userInput.Reverse()
                                          .SkipWhile(c => !char.IsLetter(c))
                                          .Reverse()
                                          .ToArray()));
