    public static int HowManyCores()
    {
        int CoresNumber = -1;
        try
        {
            CoresNumber = Environment.ProcessorCount;
            if (CoresNumber <= 2) { CoresNumber = 2; }
        }
        catch
        {
            // Log maybe
        }
        return CoresNumber;
    }
