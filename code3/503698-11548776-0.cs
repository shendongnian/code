    public static void ProcessingStarted(int messageId)
    {
        using (DataContext dc = new DataContext())
        {
            var update = dc.QueuedMessages.SingleOrDefault(m => m.Id == messageId);
            if (update != null)
            {
                update.ProcessingStarted = true;
                dc.SubmitChanges();
            }
        }
    }
