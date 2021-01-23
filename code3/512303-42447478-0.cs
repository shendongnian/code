    string[] s = new string[6]{"Fizz", "Buzz", "", "", "", ""};
    for (int i = 1; i <= 100; i++)
    {
        string output = s[(i%3)*2] + s[(i%5)+1];
        Console.WriteLine(string.IsNullOrEmpty(output)? "" + i : output);
    }
