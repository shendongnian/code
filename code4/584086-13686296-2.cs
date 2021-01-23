    public class MyPackage : Package, IOleCommandTarget
    {
    	#region IOleCommandTarget implementation
    
    	/// <summary>
    	/// The VS shell calls this function to know if a menu item should be visible and
    	/// if it should be enabled/disabled.
    	/// This is called only when the package is active.
    	/// </summary>
    	/// <param name="guidCmdGroup">Guid describing which set of commands the current command(s) belong to</param>
    	/// <param name="cCmds">Number of commands for which status are being asked</param>
    	/// <param name="prgCmds">Information for each command</param>
    	/// <param name="pCmdText">Used to dynamically change the command text</param>
    	/// <returns>HRESULT</returns>
    	public int QueryStatus(ref Guid guidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
    	{
    		// Filter out commands that are not defined by this package
    		if ( guidCmdGroup != new Guid("{00000000-0000-0000-0000-000000000000}"))
    			return (int)(Constants.OLECMDERR_E_NOTSUPPORTED);
    
    		if ( cCmds == 0 || prgCmds == null || prgCmds.Length == 0 || cCmds != prgCmds.Length )
    			return VSConstants.E_INVALIDARG;
    
    		// Show and enable all commands.
    		OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
    		for ( int i = 0; i < cCmds; i++ )
    			prgCmds[i].cmdf = (uint)cmdf;
    
    		return VSConstants.S_OK;
    	}
    
    	#endregion
    }
