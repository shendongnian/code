        StringBuilder outTxt = new StringBuilder();
        for (int i = inTxt.Length-1; i > 0; i--)
        {
            char ch = inTxt[i];
            outTxt.Append(ch);
        }
        Console.WriteLine(outTxt.ToString());
        return outTxt.ToString();
    }
