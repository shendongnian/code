    tasks.Add(
        Task.Factory.StartNew(() =>
        {
            Debug.WriteLine("Exporting " + valueParam );
            System.Threading.Thread.Sleep(500);
            lock(progressReportLock)
            {
               counter++;
               StatusMessage = string.Format("Exporting {0} / {1}", counter, count);
               Debug.WriteLine("Finished " + counter.ToString());
            }
        })
    );
