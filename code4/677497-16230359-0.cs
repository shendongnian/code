    public static bool CompareCount(int? currentCount)
    {
        int countValue = currentCount ?? 0;
        if (Properties.Settings.Default.Count == <some default value>)
        {    
            Properties.Settings.Default.Count = (int)currentCount;
            Properties.Settings.Default.Save();
        }
        else
        {
            return currentCount >= Properties.Settings.Default.Count;
        }
    }   
