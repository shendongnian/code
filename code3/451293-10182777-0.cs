    int result;
    
    public int twist(int min, int max)
    {
        Random random = new Random();
        int y = random.Next(min, max);
        result += y;
        
        System.Diagnostics.Debug.WriteLine(result);
        return result;
    }
