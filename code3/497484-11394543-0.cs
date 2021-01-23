    private string[] splitToPieces(string data, int pieces, string sep)
    {
        string[] result = new string[pieces];
        int block = data.IndexOf(sep) + 1;
        int maxBlocksPerPcs = (data.Length / pieces) / block;
        int idx = 0; int pos = 0;
        while(idx < pieces)
        {
            result[idx] = data.Substring(pos, block * maxBlocksPerPcs);
            pos += block * maxBlocksPerPcs;
            idx++;
        }
        if(pos != data.Length)
            result[pieces-1] += data.Substring(pos);
       
        return result;
    }
