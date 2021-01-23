	Runspace remoteRunspace = null;
	PSCredential psc = null;
	// If user name is not passed used the credentials of the current farm account
	if (!string.IsNullOrWhiteSpace(username))
	{
		if (!string.IsNullOrWhiteSpace(domain))
			username = domain + "\\" + username;
		SecureString secpassword = new SecureString();
		if (!string.IsNullOrEmpty(password))
		{
			foreach (char c in password)
			{
				secpassword.AppendChar(c);
			}
		}
		psc = new PSCredential(username, secpassword);
	}
	WSManConnectionInfo rri = new WSManConnectionInfo(new Uri(RemotePowerShellUrl), PowerShellSchema, psc);
	if (psc != null)
		rri.AuthenticationMechanism = AuthenticationMechanism.Credssp;
	remoteRunspace = RunspaceFactory.CreateRunspace(rri);
	remoteRunspace.Open();
	Pipeline pipeline = remoteRunspace.CreatePipeline();
	Command cmdSharePointPowershell = new Command(Commands.AddPSSnapin.CommandName);
	cmdSharePointPowershell.Parameters.Add(Commands.AddPSSnapin.Name, MicrosoftSharePointPowerShellSnapIn);
	pipeline.Commands.Add(cmdSharePointPowershell);
	pipeline.Invoke();
