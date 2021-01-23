	string loginName = HttpContext.Current.User.Identity.Name;
	Regex r = new Regex(@"\w+[\\]");
	string userName = r.Replace(loginName, "");
	throw new System.ArgumentException("Debug: '" + HttpContext.Current.User.Identity.IsAuthenticated.ToString() +"'", "userName");
	SelectQuery sQuery = new SelectQuery("Win32_UserAccount", "name='" + userName + "'");
	ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(sQuery);
	string sid = "";
	foreach (ManagementObject mObject in mSearcher.Get()) 
	{
		sid = mObject["SID"].ToString();
		break; //mSearcher.Get() is not indexable. Behold the hackyness!
	}
	string saveLocation = Microsoft.Win32.Registry.GetValue(
		"HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion\\ProfileList\\" + sid,
		"ProfileImagePath", null).ToString();
