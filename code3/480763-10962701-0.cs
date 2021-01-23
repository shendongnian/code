    namespace RemoteWMP 
    {
    	using System;
    	using System.Runtime.InteropServices;
          using WMPLib;
    
    
    	/// <summary>
    	/// This is the actual Windows Media Control.
    	/// </summary>
        [GuidAttribute("6bf52a52-394a-11d3-b153-00c04f79faa6"),
        ComVisible(true),
    	ClassInterface(ClassInterfaceType.AutoDispatch)]
    	public class RemotedWindowsMediaPlayer : 
    		IOleServiceProvider,
    		IOleClientSite
    	{
    
    		#region IOleServiceProvider Members - Working
    		/// <summary>
    		/// During SetClientSite, WMP calls this function to get the pointer to <see cref="RemoteHostInfo"/>.
    		/// </summary>
    		/// <param name="guidService">See MSDN for more information - we do not use this parameter.</param>
    		/// <param name="riid">The Guid of the desired service to be returned.  For this application it will always match
    		/// the Guid of <see cref="IWMPRemoteMediaServices"/>.</param>
    		/// <returns></returns>
    		IntPtr IOleServiceProvider.QueryService(ref Guid guidService, ref Guid riid)
    		{
    			//If we get to here, it means Media Player is requesting our IWMPRemoteMediaServices interface
    			if (riid == new Guid("cbb92747-741f-44fe-ab5b-f1a48f3b2a59"))
    			{
    				IWMPRemoteMediaServices iwmp = new RemoteHostInfo();
    				return Marshal.GetComInterfaceForObject(iwmp, typeof(IWMPRemoteMediaServices));
    			}
    
    			throw new System.Runtime.InteropServices.COMException("No Interface", (int) HResults.E_NOINTERFACE);
    		}
    		#endregion
    
    		#region IOleClientSite Members
    		/// <summary>
    		/// Not in use.  See MSDN for details.
    		/// </summary>
    		/// <exception cref="System.Runtime.InteropServices.COMException">E_NOTIMPL</exception>
    		void IOleClientSite.SaveObject() 
    		{
    			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
    		}
    
    		/// <summary>
    		/// Not in use.  See MSDN for details.
    		/// </summary>
    		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
    		object IOleClientSite.GetMoniker(uint dwAssign, uint dwWhichMoniker)
    		{
    			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
    		}
    
    		/// <summary>
    		/// Not in use.  See MSDN for details.
    		/// </summary>
    		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
    		object IOleClientSite.GetContainer() 
    		{
    			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
    		}
    
    		/// <summary>
    		/// Not in use.  See MSDN for details.
    		/// </summary>
    		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
    		void IOleClientSite.ShowObject() 		
    		{
    			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
    		}
    
    		/// <summary>
    		/// Not in use.  See MSDN for details.
    		/// </summary>
    		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
    		void IOleClientSite.OnShowWindow(bool fShow) 		
    		{
    			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
    		}
    
    		/// <summary>
    		/// Not in use.  See MSDN for details.
    		/// </summary>
    		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
    		void IOleClientSite.RequestNewObjectLayout() 		
    		{
    			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
    		}
    
    		#endregion          
    
    		/// <summary>
    		/// Default Constructor.
    		/// </summary>
    		public RemotedWindowsMediaPlayer()
    		{
    		}        
    	}   
    }
