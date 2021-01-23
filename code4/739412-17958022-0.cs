    using (System.IO.StreamReader file = new System.IO.StreamReader(@"T:\\PARTS\\DATABASE\\PARTS.txt"))
    {
        var results = new StringBuilder();
        var nextUpdate = DateTime.Now.AddMilliseconds(500);
        while ((line = file.ReadLine()) != null)
        {
            if ((backgroundWorker1.CancellationPending == true))
            {
                e.Cancel = true;
                break;
            }
            if (line.Contains(partNumbersText.Text))
            {
                results.AppendLine(line);
            }
            if (DateTime.Now > nextUpdate)
            {
                nextUpdate = DateTime.Now.AddMilliseconds(500);
                backgroundWorker1.ReportProgress(0, results.ToString());
                //move this code to the ProgressChanged event
                //matchesText.Invoke(() => matchesText.Text = results.ToString()); // Or use 
            }
        }
    }
