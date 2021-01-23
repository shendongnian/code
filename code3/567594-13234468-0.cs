    if (_isRunning)
        return;
    
    try
    {
        _isRunning = true;
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
    finally
    {  _isRunning = false; }
