        int l=0;
        string s;
        Console.WriteLine("Enter Paragraph: ");
        s = Console.ReadLine();
        foreach (char c in s)
        {
            if (!char.IsWhiteSpace(c))
            {
                l++;
            }
        }
        Console.WriteLine("Your Paragraph Length is: " + l);
        Console.ReadLine();
