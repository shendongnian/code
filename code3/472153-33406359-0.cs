    void Session_End(object sender, EventArgs e)
    {
        SampleDelete();
    }
    private static void SampleDelete()
    {
        try
        {
            string samplesss = AppDomain.CurrentDomain.BaseDirectory + "\\temp";
            string[] array1 = System.IO.Directory.GetDirectories(samplesss);
            try
            {
                foreach (string item in array1)
                {
                    System.IO.Directory.Delete(item, true);
                }
            }
            catch (Exception ex)
            { }
        }
        catch (Exception ex)
        {
        }
    }
