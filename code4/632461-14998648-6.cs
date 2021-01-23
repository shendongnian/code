    static string Generate(int length)
    {
        Random random = new Random((int)DateTime.Now.Ticks);
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < length; i++)
        {
            int x = random.Next(33, 123);
            sb.Append((char)x);
        }
            
        return sb.ToString();
    }
