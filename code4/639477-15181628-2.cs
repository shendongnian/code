    using System.Threading;
    using System.Security.AccessControl;
    using System.Security.Principal;
    
    using System.Runtime.InteropServices;   //GuidAttribute
    using System.Reflection;                //Assembly
    
    namespace ITXClimateSaverWebApp
    {
    	public class GlobalNamedLock
    	{
    		private Mutex mtx;
    
    		public GlobalNamedLock(string strLockName)
    		{
   			//Name must be provided!
    			if(string.IsNullOrWhiteSpace(strLockName))
    			{
    				//Use default name
    				strLockName = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
    			}
    
    			//Create security permissions for everyone
    			//It is needed in case the mutex is used by a process with
    			//different set of privileges than the one that created it
    			//Setting it will avoid access_denied errors.
    			MutexSecurity mSec = new MutexSecurity();
    			mSec.AddAccessRule(new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
    				MutexRights.FullControl, AccessControlType.Allow));
    
    			//Create the global mutex
    			bool bCreatedNew;
    			mtx = new Mutex(false, @"Global\" + strLockName, out bCreatedNew, mSec);
    		}
    
    		public bool enterCRITICAL_SECTION()
    		{
    			//Enter critical section
    			//INFO: May throw an exception!
    			//RETURN:
    			//		= 'true' if successfully entered
    			//		= 'false' if failed (DO NOT continue!)
    
    			//Wait
    			return mtx.WaitOne();
    		}
    
    		public void leaveCRITICAL_SECTION()
    		{
    			//Leave critical section
    			//INFO: May throw an exception!
    
    			//Release it
    			mtx.ReleaseMutex();
    		}
    	}
    }
