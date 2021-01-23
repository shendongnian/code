    if (finish.Subtract(start).TotalSeconds < waitTime)
    {
         if (syncWorker.Status == WorkerStatus.CompletedSuccess)
         {
              successes++;
         }
    }
    else
    {
         syncThread.Abort();
         syncThread.Join();
         sb.AppendLine("Sync Manager (" + ID + ") - FSW (" + syncWorker.ID + ") - Transfer timed out after " + waitTime + " seconds.");
    }
