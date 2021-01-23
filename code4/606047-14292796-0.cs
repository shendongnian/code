    public static void Flush()
    {
        Application.DoEvents();
        while ((events != null) && (events.Count > 0))
        {
            Application.DoEvents();
        }
    }
