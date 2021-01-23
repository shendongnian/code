    var teststring = "Test <b>test</b> lorem <i>ipsum</i>";
    var pattern = @"(?!</?b>)<.*?>"; // assuming open and closing tags are retained
    Console.WriteLine(Regex.Replace
           (teststring,
             pattern,
             String.Empty,
             RegexOptions.Multiline));
