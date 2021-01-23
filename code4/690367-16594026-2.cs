    // at this point, it's assumed that inputText characters are all digits.
    // you should have code that confirms this (var shouldContinue = inputText.All(char.IsDigit);)
    var inputText = "4565457";
    var input = inputText.Select(c => c - 48);   // quick and dirty "ToInt" per char
    
    var multipliers = Enumerable.Range(2, inputText.Length).Reverse();
    var multiplied = input.Zip(multipliers, (a, b) => a*b);
    listBox1.Items.AddRange(multiplied.ToArray());
