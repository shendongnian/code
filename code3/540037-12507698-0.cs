    try
    {
        if (!bw.IsBusy)
            bw.RunWorkerAsync();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
