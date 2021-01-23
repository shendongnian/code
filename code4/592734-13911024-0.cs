    using System.Timers.Timer;
    static public void Tick(Object stateInfo)
    {
        try
        {
            timer.Stop();
            
            List<RemindObject> remList = Utils.Reminds;
            foreach (RemindObject remind in remList)
            {
                if (remind.reminTime.CompareTo(DateTime.Now) < 0)
                {
                    Utils.ItsTimeToRemind(remind.FormTag);
                }
            }
        }
        catch(Exception ex)
        {
            // log exception, etc
        }
        finally
        {
            timer.Start();
        }
    }
