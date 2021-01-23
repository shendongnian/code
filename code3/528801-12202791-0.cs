    var letters = Enumerable.Repeat(Enumerable.Range((int)'a', 'z'-'a' + 1).Select(e => (char)e), 3).Select (e => e.ToList()).ToList();
    for(int i = 0, j = 0; i < passwordBytes.Length; i++)
    {
        j = i % 3;
        for(int k = 0; k < letters[j].Count; k++)
        {
            byte r = (byte)(letters[j][k] ^ passwordBytes[i]);
            if(r < 32 || r > 122) letters[j].RemoveAt(k);
        }
    }
