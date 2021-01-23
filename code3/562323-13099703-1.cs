    private static int m_NumberOfRetries = 5; //Define how many times application can "restart" itself to avoid stackoverflow. 
    static void Main(string[] args)
    {
        try
        {
            //Do something useful
        }
        catch
        {
            if (m_NumberOfRetries != 0)
            {
                Main(args);
                m_NumberOfRetries--;
            }
        }
     }
