    public void OnChanged(object source, FileSystemEventArgs e)
    {
        try
        {
            watcher.EnableRaisingEvents = false;
            FileInfo objFileInfo = new FileInfo(e.FullPath);
            if (!objFileInfo.Exists) return;
            System.Threading.Thread.Sleep(5000);
            FileInfo fileinformatie = new FileInfo(e.FullPath);
            string strCreateTime = fileinformatie.CreationTime.ToString();
            string strCreateDate = fileinformatie.CreationTime.ToString();
            
            //Ignore this, only for my file information.
            strCreateTime = strCreateTime.Remove(strCreateTime.LastIndexOf(" "));
            strCreateDate = strCreateDate.Remove(0,strCreateDate.LastIndexOf(" "));
            ProcessAllFiles(e.FullPath, strCreateTime, strCreateDate);
        }
        catch (Exception ex)
        {
            ToolLabel.Text = ex.Message.ToString();
        }
        finally
        {
            watcher.EnableRaisingEvents = true;
        }
    }
