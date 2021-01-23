    var s = @"Hello,
    world";
    
    var builder = new StringBuilder();
    
    foreach (var c in s)
    {
        if (Char.IsLetterOrDigit(c) || Char.IsPunctuation(c))
            builder.Append(c);
        else
        {
            var newStr = string.Format("#{0}$", ((int)c).ToString("X"));
            builder.Append(newStr);
        }
    }
    Console.WriteLine(builder.ToString());
