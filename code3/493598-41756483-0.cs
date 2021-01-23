      /// <summary>Cancels the <see cref="T:System.Threading.CancellationTokenSource" /> after the specified duration.</summary>
      /// <param name="source">The CancellationTokenSource.</param>
      /// <param name="dueTime">The due time in milliseconds for the source to be canceled.</param>
      public static void CancelAfter(this CancellationTokenSource source, int dueTime)
      {
        if (source == null)
          throw new NullReferenceException();
        if (dueTime < -1)
          throw new ArgumentOutOfRangeException("dueTime");
        Contract.EndContractBlock();
        Timer timer = (Timer) null;
        timer = new Timer((TimerCallback) (state =>
        {
          timer.Dispose();
          TimerManager.Remove(timer);
          try
          {
            source.Cancel();
          }
          catch (ObjectDisposedException ex)
          {
          }
        }), (object) null, -1, -1);
        TimerManager.Add(timer);
        timer.Change(dueTime, -1);
      }
