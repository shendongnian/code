    private string[] splitToBlocks(string data, int numBlocks, string sep)
    {
        // We return an array of the request length
        string[] result = new string[numBlocks];
        // Lenght of one record (till the sep and include it)
        int recSize = data.IndexOf(sep) + 1;
        // How many records for each block are allowed
        int maxRecordsPerBlock = (data.Length / numBlocks) / recSize;
        // The length of one standard block returned
        int blockLen = recSize * maxRecordsPerBlock;
        int idx = 0; int pos = 0;
        while(idx < numBlocks)
        {
            result[idx] = data.Substring(pos, blockLen);
            pos += blockLen;
            idx++;
        }
        // Add the remainder to the last block
        if(pos != data.Length)
            result[pieces-1] += data.Substring(pos);
       
        return result;
    }
