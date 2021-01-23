    //List of characters to substitute in place of '?'
    List<char> validChars = new List<char>() { 'w', 'x', 'y', 'z' };
    //List of combinations generated
    List<string> combos = new List<string>();
    void GenerateCombos(string mask, string combination)
    {
        if (mask.Length <= 0)
        {
            //No more chars left in the mask, add this combination to the solution list.
            combos.Add(combination);
            return;
        }
        if (mask[0] != '?')
        {
            //This is not a wildcard, append the first character of the mask
            //to the combination string and call the function again with 
            //the remaining x characters of the mask.
            GenerateCombos(mask.Substring(1), combination + mask[0]);
        }
        else
        {
            //This is a wildcard, so for each of the valid substitution chars,
            //append the char to the combination string and call again
            //with the remaining x chars of the mask.
            validChars.ForEach(c => GenerateCombos(mask.Substring(1), combination + c));
        }
    }
