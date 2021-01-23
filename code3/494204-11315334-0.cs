    public bool GetVideoThumbnail(string path, string saveThumbnailTo, int seconds)
    {
        string parameters = string.Format("-ss {0} -i {1} -f image2 -vframes 1 -y {2}", seconds, path, saveThumbnailTo);
        var processInfo = new ProcessStartInfo();
        processInfo.FileName = pathToConvertor;
        processInfo.Arguments = parameters;
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        File.Delete(saveThumbnailTo);
        using(var process = new Process())
        {
            process.StartInfo = processInfo;
            process.Start();
            process.WaitForExit();
        }
        return File.Exists(saveThumbnailTo);
    }
