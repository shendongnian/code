        public int getLastInt(string line)
        {
            int offset = line.Length;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    offset--;
                }
                else
                {
                    if (offset == line.Length)
                    {
                        // No int at the end
                        return -1;
                    }
                    return int.Parse(line.Substring(offset));
                }
            }
            return int.Parse(line.Substring(offset));
        }
