	SPSecurity.RunWithElevatedPrivileges(() =>
	{
		HttpContext httpContext = HttpContext.Current;
		try
		{
			SPServiceContext serviceContext = SPServiceContext.GetContext(httpContext);
			HttpContext.Current = null; // Hack !!!
			UserProfileManager upm = new UserProfileManager(serviceContext);
			//.. update your property which has "IsAdminEditable" set to true and "IsUserEditable" set to false
		}
		finally
		{
			//restore old context
			HttpContext.Current = httpContext;
		}
	}
