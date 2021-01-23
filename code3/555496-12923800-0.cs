    var s = "abcdefg";
    foreach (var character in s)
    {
        switch (character)
        {
            case 'c':
                try
                {
                    throw new Exception("c sucks");
                }
                catch
                {
                    // Swallow the exception and move on?
                }
                break;
            default:
                Console.WriteLine(character);
                break;
        }
    }
