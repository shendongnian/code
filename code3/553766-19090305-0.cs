    public static int GetHresult(this IOException ex)
    {
       return (int)ex.GetType().GetProperty("HResult", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ex, null);
    }
   
   
