	void Main()
	{
		IEnumerable<MyApplication> myApplications=
			new System.Collections.Generic.List<MyApplication>();
		ServiceAccount serviceAccount=new ServiceAccount();
		serviceAccount.DomainServiceAccount=@"test\\account";
		((List<MyApplication>)myApplications).Add(new MyApplication() { 
			component=serviceAccount });
		XDocument xDocument = new XDocument(
			new XDeclaration("1.0", "utf-8", null),
			new XElement("MyAppsTable",
					myApplications.Select(component => new XElement("MyApps",
						new XElement("ChangeResult", string.Empty),
						new XElement("ChangeRunAsName", 
							serviceAccount.DomainServiceAccount.Replace("\\\\", "\\"))
						)
					)
			)
		);
		xDocument.Dump();	
	}
