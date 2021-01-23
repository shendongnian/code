    smtp.SendCompleted += delegate(object s, System.ComponentModel.AsyncCompletedEventArgs    e)
    {
        if (e.Error != null)
         {
            System.Diagnostics.Trace.TraceError(e.Error.ToString());
         }
    };
