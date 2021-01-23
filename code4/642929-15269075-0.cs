    string str = "MD00494";
    string digits = new string(str.Where(char.IsDigit).ToArray());
    string letters = new string(str.Where(char.IsLetter).ToArray());
    int number;
    if (!int.TryParse(digits, out number)) //int.Parse would do the job since only digits are selected
    {
        Console.WriteLine("Something weired happened");
    }
    string newStr = letters + (++number).ToString("D5");
