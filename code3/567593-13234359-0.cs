    timer.Stop();
    try
    {
        string[] filePaths = Directory.GetFiles(@"D:\ISS_Homewrok\");
        foreach (string filePath in filePaths)
        {
            SendEmail(filePath);
            File.Delete(filePath);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
    timer.Start();
