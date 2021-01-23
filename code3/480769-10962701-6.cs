    using System;
    
    namespace RemoteWMP
    {
    	using System.Runtime.InteropServices;
    
    	#region Useful COM Enums
    	/// <summary>
    	/// Represents a collection of frequently used HRESULT values.
    	/// You may add more HRESULT VALUES, I've only included the ones used 
    	/// in this project.
    	/// </summary>
    	public enum HResults
    	{
    		/// <summary>
    		/// HRESULT S_OK
    		/// </summary>
    		S_OK = unchecked((int)0x00000000),
    		/// <summary>
    		/// HRESULT S_FALSE
    		/// </summary>
    		S_FALSE = unchecked((int)0x00000001),
    		/// <summary>
    		/// HRESULT E_NOINTERFACE
    		/// </summary>
    		E_NOINTERFACE = unchecked((int)0x80004002),
    		/// <summary>
    		/// HRESULT E_NOTIMPL
    		/// </summary>
    		E_NOTIMPL = unchecked((int)0x80004001),
            /// <summary>
            /// USED CLICKED CANCEL AT SAVE PROMPT
            /// </summary>
            OLE_E_PROMPTSAVECANCELLED = unchecked((int)0x8004000C),
    
    	}
    
    	/// <summary>
    	/// Enumeration for <see cref="IOleObject.GetMiscStatus"/>
    	/// </summary>
    	public enum DVASPECT
    	{
    		/// <summary>
    		/// See MSDN for more information.
    		/// </summary>
    		Content = 1,		
    		/// <summary>
    		/// See MSDN for more information.
    		/// </summary>
    		Thumbnail = 2,
    		/// <summary>
    		/// See MSDN for more information.
    		/// </summary>
    		Icon = 3,
    		/// <summary>
    		/// See MSDN for more information.
    		/// </summary>
    		DocPrint = 4
    	}
        /// <summary>
        /// Emumeration for <see cref="IOleObject.Close"/>
        /// </summary>
        public enum TAGOLECLOSE :uint{
          OLECLOSE_SAVEIFDIRTY   = unchecked((int)0),
          OLECLOSE_NOSAVE        = unchecked((int)1),
          OLECLOSE_PROMPTSAVE    = unchecked((int)2) 
        } 
    
    	#endregion
    
    	#region IWMPRemoteMediaServices
    	/// <summary>
    	/// Interface used by Media Player to determine WMP Remoting status.
    	/// </summary>
    	[ComImport,
    	ComVisible(true),
    	InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    	Guid("CBB92747-741F-44fe-AB5B-F1A48F3B2A59")]
    	public interface IWMPRemoteMediaServices
    	{
    		
    		/// <summary>
    		/// Service type.
    		/// </summary>
    		/// <returns><code>Remote</code> if the control is to be remoted (attached to WMP.) 
    		/// <code>Local</code>if this is an independent WMP instance not connected to WMP application.  If you want local, you shouldn't bother
    		/// using this control!
    		/// </returns>
    		[return: MarshalAs(UnmanagedType.BStr)] 
    		string GetServiceType();
    
    		/// <summary>
    		/// Value to display in Windows Media Player Switch To Application menu option (under View.)
    		/// </summary>
    		/// <returns></returns>
    		[return: MarshalAs(UnmanagedType.BStr)] 
    		string GetApplicationName();
    
    		/// <summary>
    		/// Not in use, see MSDN for details.
    		/// </summary>
    		/// <param name="name"></param>
    		/// <param name="dispatch"></param>
    		/// <returns></returns>
    		[PreserveSig]
    		[return: MarshalAs(UnmanagedType.U4)]
    		HResults GetScriptableObject([MarshalAs(UnmanagedType.BStr)] out string name, 
    			[MarshalAs(UnmanagedType.IDispatch)] out object dispatch);
    
    		/// <summary>
    		/// Not in use, see MSDN for details.
    		/// </summary>
    		/// <param name="file"></param>
    		/// <returns></returns>
    		[PreserveSig]
    		[return: MarshalAs(UnmanagedType.U4)]
    		HResults GetCustomUIMode([MarshalAs(UnmanagedType.BStr)] out string file);
    	}
    
    	#endregion
    
    	#region IOleServiceProvider
    	/// <summary>
    	/// Interface used by Windows Media Player to return an instance of IWMPRemoteMediaServices.
    	/// </summary>
    	[ComImport,
    	GuidAttribute("6d5140c1-7436-11ce-8034-00aa006009fa"),
    	InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown),
    	ComVisible(true)]
    	public interface IOleServiceProvider
    	{
    		/// <summary>
    		/// Similar to QueryInterface, riid will contain the Guid of an object to return.
    		/// In our project we will look for <see cref="IWMPRemoteMediaServices"/> Guid and return the object
    		/// that implements that interface.
    		/// </summary>
    		/// <param name="guidService"></param>
    		/// <param name="riid">The Guid of the desired Service to provide.</param>
    		/// <returns>A pointer to the interface requested by the Guid.</returns>
    		IntPtr QueryService(ref Guid guidService, ref Guid riid);
    	}
    
    	/// <summary>
    	/// This is an example of an INCORRECT entry - do not use, unless you want your app to break.
    	/// </summary>
    	[ComImport,
    	GuidAttribute("6d5140c1-7436-11ce-8034-00aa006009fa"),
    	InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown),
    	ComVisible(true)]
    	public interface BadIOleServiceProvider
    	{
    		/// <summary>
    		/// This is incorrect because it causes our return interface to be boxed
    		/// as an object and a COM callee may not get the correct pointer.
    		/// </summary>
    		/// <param name="guidService"></param>
    		/// <param name="riid"></param>
    		/// <returns></returns>
    		/// <example>
    		/// For an example of a correct definition, look at <see cref="IOleServiceProvider"/>.
    		/// </example>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object QueryService(ref Guid guidService, ref Guid riid);
    	}
    	#endregion
    
    	#region IOleClientSite
    	/// <summary>
    	/// Need to implement this interface so we can pass it to <see cref="IOleObject.SetClientSite"/>.
    	/// All functions return E_NOTIMPL.  We don't need to actually implement anything to get
    	/// the remoting to work.
    	/// </summary>
    	[ComImport,
    	ComVisible(true),
    	Guid("00000118-0000-0000-C000-000000000046"),
    	InterfaceType(ComInterfaceType.InterfaceIsIUnknown) ]
    	public interface IOleClientSite
    	{
    		/// <summary>
    		/// See MSDN for more information.  Throws <see cref="COMException"/> with id of E_NOTIMPL.
    		/// </summary>
    		/// <exception cref="COMException">E_NOTIMPL</exception>
    		void SaveObject();
    		
    		/// <summary>
    		/// See MSDN for more information.  Throws <see cref="COMException"/> with id of E_NOTIMPL.
    		/// </summary>
    		/// <exception cref="COMException">E_NOTIMPL</exception>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object GetMoniker(uint dwAssign, uint dwWhichMoniker);
    
    		/// <summary>
    		/// See MSDN for more information.  Throws <see cref="COMException"/> with id of E_NOTIMPL.
    		/// </summary>
    		/// <exception cref="COMException">E_NOTIMPL</exception>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object GetContainer();
    		
    		/// <summary>
    		/// See MSDN for more information.  Throws <see cref="COMException"/> with id of E_NOTIMPL.
    		/// </summary>
    		/// <exception cref="COMException">E_NOTIMPL</exception>
    		void ShowObject();
    
    		/// <summary>
    		/// See MSDN for more information.  Throws <see cref="COMException"/> with id of E_NOTIMPL.
    		/// </summary>
    		/// <exception cref="COMException">E_NOTIMPL</exception>
    		void OnShowWindow(bool fShow);
    		
    		/// <summary>
    		/// See MSDN for more information.  Throws <see cref="COMException"/> with id of E_NOTIMPL.
    		/// </summary>
    		/// <exception cref="COMException">E_NOTIMPL</exception>
    		void RequestNewObjectLayout();
    	}
    	#endregion
    
    	#region IOleObject
    	/// <summary>
    	/// This interface is implemented by WMP ActiveX/COM control.
    	/// The only function we need is <see cref="SetClientSite"/>.
    	/// </summary>
    	[ComImport, ComVisible(true),
    	Guid("00000112-0000-0000-C000-000000000046"),
    	InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    	public interface IOleObject
    	{
    		/// <summary>
    		/// Used to pass our custom <see cref="IOleClientSite"/> object to WMP.  The object we pass must also
    		/// implement <see cref="IOleServiceProvider"/> to work right.
    		/// </summary>
    		/// <param name="pClientSite">The <see cref="IOleClientSite"/> to pass.</param>
    		void SetClientSite(IOleClientSite pClientSite);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		IOleClientSite GetClientSite();
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void SetHostNames(
    			[MarshalAs(UnmanagedType.LPWStr)]string szContainerApp, 
    			[MarshalAs(UnmanagedType.LPWStr)]string szContainerObj);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void Close(uint dwSaveOption);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void SetMoniker(uint dwWhichMoniker, object pmk);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object GetMoniker(uint dwAssign, uint dwWhichMoniker);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void InitFromData(object pDataObject, bool fCreation, uint dwReserved);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		object GetClipboardData(uint dwReserved);
    
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void DoVerb(uint iVerb, uint lpmsg, [MarshalAs(UnmanagedType.Interface)]object pActiveSite, 
    			uint lindex, uint hwndParent, uint lprcPosRect);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object EnumVerbs();
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void Update();
    		
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[PreserveSig]
    		[return: MarshalAs(UnmanagedType.U4)]
    		HResults IsUpToDate();
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		Guid GetUserClassID();
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[return: MarshalAs(UnmanagedType.LPWStr)]
    		string GetUserType(uint dwFormOfType);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void SetExtent(uint dwDrawAspect, [MarshalAs(UnmanagedType.Interface)] object psizel);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object GetExtent(uint dwDrawAspect);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		uint Advise([MarshalAs(UnmanagedType.Interface)]object pAdvSink);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void Unadvise(uint dwConnection);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		[return: MarshalAs(UnmanagedType.Interface)]
    		object EnumAdvise();
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		uint GetMiscStatus([MarshalAs(UnmanagedType.U4)] DVASPECT dwAspect);
    
    		/// <summary>
    		/// Implemented by Windows Media Player ActiveX control.
    		/// See MSDN for more information.
    		/// </summary>
    		void SetColorScheme([MarshalAs(UnmanagedType.Interface)] object pLogpal);
    	}
    	#endregion
    
    }
