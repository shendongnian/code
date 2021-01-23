    var dte = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
	Microsoft.VisualStudio.Shell.Interop.IVsUIHierarchyWindow hierarchy;
	ServiceProvider sp = new ServiceProvider((Microsoft.VisualStudio.OLE.Interop.IServiceProvider)dte);
	IVsSolution sol = (IVsSolution)sp.GetService(typeof(SVsSolution));
	
	foreach (ProjInfo info in GetProjectInfo(sol))
	{
    	info.Dump();
		
	}
    //from http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/60fdd7b4-2247-4c18-b1da-301390edabf3/
    static IEnumerable<ProjInfo> GetProjectInfo(IVsSolution sol)
    {
      Guid ignored = Guid.Empty;
      IEnumHierarchies hierEnum;
      if (ErrorHandler.Failed(sol.GetProjectEnum((int)__VSENUMPROJFLAGS.EPF_ALLPROJECTS, ref ignored, out hierEnum)))
      {
        yield break;
      }
      IVsHierarchy[] hier = new IVsHierarchy[1];
      uint fetched;
      while ((hierEnum.Next((uint)hier.Length, hier, out fetched) == VSConstants.S_OK) && (fetched == hier.Length))
      {
        int res = (int)VSConstants.S_OK;
		
        Guid projGuid;
        if (ErrorHandler.Failed(res = sol.GetGuidOfProject(hier[0], out projGuid)))
        {
            Debug.Fail(String.Format("IVsolution::GetGuidOfProject returned 0x{0:X}.", res));
            continue;
        }
		
        string uniqueName;
        if (ErrorHandler.Failed(res = sol.GetUniqueNameOfProject(hier[0], out uniqueName)))
        {
            Debug.Fail(String.Format("IVsolution::GetUniqueNameOfProject returned 0x{0:X}.", res));
            continue;
        }
		if( System.IO.Path.GetInvalidPathChars().Any (p =>uniqueName.Contains(p) ))
		{
			uniqueName.Dump("invalid filename found");
			yield return new ProjInfo(projGuid,uniqueName);
		} 
		else {
        	yield return new ProjInfo(projGuid, Path.GetFileName(uniqueName).BeforeOrSelf("{"));
		}
      }
    }
