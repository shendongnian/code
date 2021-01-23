    string Scramble(string input)
    {
        string input = input + "x";
        List<char> charList = input.ToList();
        StringBuilder output;
        Random r = new Random((int) DateTime.Now.Ticks & 0x0000FFFF); 
        while (charList.Count)
        {
            int randomIndex = r.Next(0, charList.Count);
            output.Append(charList.ElementAt(randomIndex));
            charList.RemoveAt(randomIndex);
        }
        return output.ToString();
    }
