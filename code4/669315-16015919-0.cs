    public async Task StartLoading(string[] files)
    {
        return Task.Factory.StartNew(() =>
            {
                foreach (string file in files)
                {
                    Stopwatch swatch = new Stopwatch();
                    swatch.Start();
                    System.Threading.Thread.Sleep(5000);
                    FileInfo finfo = new FileInfo(file);
                    using (ExcelPackage package = new ExcelPackage(finfo))
                    {
                            // very long operation
                    }
                } // For Each    
            });
    } // StartLoading
