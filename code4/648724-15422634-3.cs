    public class MyNamedLock
    {
        private Mutex mtx = null;
        private string _strLkName;
        
        // to know if finally we get lock
        bool cNeedToBeRelease = false;
    
        public MyNamedLock(string strLockName)
        {
            _strLkName = strLockName;
            //...
    
            mtx = new Mutex(false, _strLkName, out bCreatedNew, mSec);
        }
    
        public bool enterLockWithTimeout(int nmsWait = 30 * 1000)
        {
            _nmsWaitLock = nmsWait;
            bool cLock = false;
    		try
    		{
    			cLock = mtx.WaitOne(nmsWait, false);
    			cNeedToBeRelease = cLock;    
    		}
    		catch (AbandonedMutexException)
    		{
    			// http://stackoverflow.com/questions/654166/wanted-cross-process-synch-that-doesnt-suffer-from-abandonedmutexexception
    			// http://msdn.microsoft.com/en-us/library/system.threading.abandonedmutexexception.aspx
    			cNeedToBeRelease = true;
    		}
    		catch (Exception x)
    		{
    			// log the error
    			Debug.Fail("Check the reason of fail:" + x.ToString());
    		}            
    
    		return cLock;        
        }
    
        public void leaveLock()
        {
            _nmsWaitLock = 0;
            
    		if (mtx != null)
    		{
    			if (cNeedToBeRelease)
    			{
    				try
    				{
    					mtx.ReleaseMutex();
    					cNeedToBeRelease = false;    
    				}
    				catch (Exception x)
    				{
    					Debug.Fail("Check the reason of fail:" + x.ToString());
    				}
    			}
    
    			mtx.Close();
    			mtx.Dispose();
    			mtx = null;
    		}
        }
    }
