    string str = Console.ReadLine();
    string digits = new string(str.Where(char.IsDigit).ToArray());
    string letters = new string(str.Where(char.IsLetter).ToArray());
    string newStr;
    int number;
    if (!int.TryParse(digits, out number)) 
    {
      Console.WriteLine("Something weird happened");
    }
    if (digits.StartsWith("0"))
    {
      newStr = letters + (++number).ToString("D5");
    }
    else
    {
      newStr = letters + (++number).ToString();
    }
