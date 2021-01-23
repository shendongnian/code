    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (e.ProgressPercentage != 0)
      {
        double percentageComplete = (double)e.ProgressPercentage / m_csNumLines;
 
        TimeSpan timeSinceStart = DateTime.Now.Subtract(m_operationStart);
        TimeSpan totalTime = TimeSpan.FromMilliseconds(timeSinceStart.TotalMilliseconds / percentageComplete);
        TimeSpan timeLeft = totalTime - timeSinceStart;
        
        Console.WriteLine("TotalEstTime: " + totalTime + " TimeLeft: " + timeLeft);
        // Update the progress label
        resultLabel.Text = "Line " + e.ProgressPercentage.ToString() + " of " + m_csNumLines + " at " + (int)(100.0 * percentageComplete) + "% loaded";
      }
      else
        resultLabel.Text = "Line " + e.ProgressPercentage.ToString() + " of " + m_csNumLines;
    }
