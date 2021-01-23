    using (SvnClient client = new SvnClient())
    {
    	//Save localy new Authentication credentials
    	client.Authentication.UserNamePasswordHandlers
    	+= delegate(object obj, SharpSvn.Security.SvnUserNamePasswordEventArgs args)
    	{
    		args.UserName = "username";
    		args.Password = "password";
            args.Save= true;
    	};
    }
