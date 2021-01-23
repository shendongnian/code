    string mutexName = String.Format(@"Global\{0}", caseId.ToString());
    Mutex mutex;
    if (!Mutex.TryOpenExisting(mutexName, out mutex))
    {
         bool isNew;
         MutexSecurity mSec = new MutexSecurity();
         SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
         MutexAccessRule rule = new MutexAccessRule(sid, MutexRights.FullControl, AccessControlType.Allow);
          mSec.AddAccessRule(rule);
          mutex = new Mutex(false, mutexName, out isNew, mSec);
    }
    if (mutex.WaitOne(5000))
    {
         try
         {
              // read/write/modify the file
         }
         finally 
         {
              mutex.ReleaseMutex();
         }
    }
    else
    {
         Common.LogInfoMessage(String.Format("Timed out waiting for pdf mutex. CaseId: {0}", caseId));
    }
