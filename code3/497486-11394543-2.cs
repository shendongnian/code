        private string[] splitToBlocks(string data, int numBlocks, char sep)
        {
            // We return an array of the request length
            string[] result = new string[numBlocks];
            // The optimal size of each block
            int blockLen = (data.Length / numBlocks);
            int idx = 0; int pos = 0; int lastSepPos = blockLen;
            while (idx < numBlocks)
            {
                // Search backwards for the first sep starting from the lastSepPos
                char c = data[lastSepPos];
                while (c != sep) { lastSepPos--; c = data[lastSepPos]; }
                // Get the block data in the result array
                result[idx] = data.Substring(pos, (lastSepPos + 1) - pos);
                
                // Reposition for then next block
                idx++;
                pos = lastSepPos + 1;
                
                if(idx == numBlocks-1)
                    lastSepPos = data.Length - 1;
                else
                    lastSepPos = blockLen * (idx + 1);
            }
            return result;
        }
