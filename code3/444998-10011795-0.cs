    public static class ServerUtilities
    {
        public static bool IsValidToRun(Version desiredVersion)
        {
            if (_serverVersion >= desiredVersion)
                return true;
            else if (/* your other logic to determine if they're in some acceptable range */)
                return true;
    
            return false;
        }
    }
