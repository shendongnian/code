    using System;
    namespace RemoteWMP
    {
    	using System.Runtime.InteropServices;
    
    	/// <summary>
    	/// This class contains the information to return to Media Player about our remote service.
    	/// </summary>
    	[ComVisible(true)]
    	[ClassInterface(ClassInterfaceType.None)]
    	public class RemoteHostInfo : 
    		IWMPRemoteMediaServices
    	{
    		#region IWMPRemoteMediaServices Members
    		/// <summary>
    		/// Returns "Remote" to tell media player that we want to remote the WMP application.
    		/// </summary>
    		/// <returns></returns>
    		public string GetServiceType()
    		{	
    			return "Remote";
    		}
    
    		/// <summary>
    		/// The Application Name to show in Windows Media Player switch to menu
    		/// </summary>
    		/// <returns></returns>
    		public string GetApplicationName()
    		{
    			return System.Diagnostics.Process.GetCurrentProcess().ProcessName;
    		}
    
    		/// <summary>
    		/// Not in use, see MSDN for more info.
    		/// </summary>
    		/// <param name="name"></param>
    		/// <param name="dispatch"></param>
    		/// <returns></returns>
    		public HResults GetScriptableObject(out string name, out object dispatch)
    		{
    			name = null;
    			dispatch = null;
    
    			//return (int) HResults.S_OK;//NotImplemented
    			return HResults.E_NOTIMPL;
    		}
    
    		/// <summary>
    		/// For skins, not in use, see MSDN for more info.
    		/// </summary>
    		/// <param name="file"></param>
    		/// <returns></returns>
    		public HResults GetCustomUIMode(out string file)
    		{
    			file = null;
    
    			return HResults.E_NOTIMPL;//NotImplemented
    		}
    
    		#endregion
    	}
    }
