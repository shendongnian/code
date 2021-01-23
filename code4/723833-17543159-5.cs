    public static class Ext
    {
        public static bool AnyMessageContains(this Exception ex, string text)
        {
            while (ex != null)
	        {
                if(ex.Message.Contains(text))
                    return true;
                ex = ex.InnerException;
	        }
            return false;
        }
    }
