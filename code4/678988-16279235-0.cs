    string input = Console.ReadLine();                // ABC.ABC.
    int index = input.Select((c, i) => new { c, i })
                     .Where(x => char.IsLetter(x.c))
                     .Max(x => x.i);
    string trimmedInput = input.Substring(0, index + 1);
    Console.WriteLine(trimmedInput);                  // ABC.ABC
