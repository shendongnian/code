	public static Collection<PSObject> RunScript(string strScript)
	{
	  HttpContext.Current.Session["ScriptError"] = "";
	  System.Uri serverUri = new Uri(String.Format("http://exchangsserver.contoso.com/powershell?serializationLevel=Full"));
	  RunspaceConfiguration rc = RunspaceConfiguration.Create();
	  WSManConnectionInfo wsManInfo = new WSManConnectionInfo(serverUri, SHELL_URI, (PSCredential)null);
	  using (Runspace runSpace = RunspaceFactory.CreateRunspace(wsManInfo))
	  {
	    runSpace.Open();
	    PowerShell posh = PowerShell.Create();
	    posh.Runspace = runSpace;
	    posh.AddScript(strScript);
	    Collection<PSObject> results = posh.Invoke();
	    if (posh.Streams.Error.Count > 0)
	    {
	      bool blTesting = false;
	      string strType = HttpContext.Current.Session["Type"].ToString();
	      ErrorRecord err = posh.Streams.Error[0];
	      if (err.CategoryInfo.Reason == "ManagementObjectNotFoundException")
	      {
		HttpContext.Current.Session["ScriptError"] = "Management Object Not Found Exception Error " + err + " running command " + strScript;
		runSpace.Close();
		return null;
	      }
	      else if (err.Exception.Message.ToString().ToLower().Contains("is of type usermailbox.") && (strType.ToLower() == "mailbox"))
	      {
		HttpContext.Current.Session["ScriptError"] = "Mailbox already exists.";
		runSpace.Close();
		return null;
	      }
	      else
	      {
		HttpContext.Current.Session["ScriptError"] = "Error " + err + "<br />Running command " + strScript;
		fnWriteLog(HttpContext.Current.Session["ScriptError"].ToString(), "error", strType, blTesting);
		runSpace.Close();
		return null;
	      }
	    }
	    runSpace.Close();
	    runSpace.Dispose();
	    posh.Dispose();
	    posh = null;
	    rc = null;
	    if (results.Count != 0)
	    {
	      return results;
	    }
	    else
	    {
	      return null;
	    }
	  }
	}
