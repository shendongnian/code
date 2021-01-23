    foreach (var pathCartella in folderList)
    {
        try
        {
            // some operation
    
    
        }
        catch (Exception err)
        {
            // some operation
            return;
        }
        finally
        {
            if (txtMonitor.InvokeRequired)
            {
                txtMonitor.BeginInvoke(new MethodInvoker(delegate { txtMonitor.AppendText(pathCartella + Environment.NewLine); }));
            }
        }
    }
