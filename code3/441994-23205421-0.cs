    private string InsertStrings(string s, int insertEvery, char insert)
    {
        char[] ins = s.ToCharArray();
        int length = s.Length + (s.Length / insertEvery);
        if (ins.Length % insertEvery == 0)
        {
            length--;
        }
        var outs = new char[length];
        long di = 0;
        long si = 0;
        while (si < s.Length - insertEvery)
        {
            Array.Copy(ins, si, outs, di, insertEvery);
            si += insertEvery;
            di += insertEvery;
            outs[di] = insert;
            di ++;
        }
        Array.Copy(ins, si, outs, di, ins.Length - si);
        return new string(outs);
    }
