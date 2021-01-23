        private Stream ReadWhenAvailable(FileInfo finfo, TimeSpan? ts = null) => Task.Run(() =>
        {
            ts = ts == null ? new TimeSpan(long.MaxValue) : ts;
            var start = DateTime.Now;
            while (DateTime.Now - start < ts)
            {
                Thread.Sleep(200);
                try
                {
                    return new FileStream(finfo.FullName, FileMode.Open);
                }
                catch { }
            }
            return null;
        })
        .Result;
