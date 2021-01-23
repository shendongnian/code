    public virtual void Install(IDictionary stateSaver)
	{
		if (stateSaver == null)
		{
			throw new ArgumentException(Res.GetString("InstallNullParameter", new object[] { "stateSaver" }));
		}
		try
		{
			this.OnBeforeInstall(stateSaver);
		}
		catch (Exception exception)
		{
			this.WriteEventHandlerError(Res.GetString("InstallSeverityError"), "OnBeforeInstall", exception);
			throw new InvalidOperationException(Res.GetString("InstallEventException", new object[] { "OnBeforeInstall", base.GetType().FullName }), exception);
		}
		int num = -1;
		ArrayList list = new ArrayList();
		try
		{
			for (int i = 0; i < this.Installers.Count; i++)
			{
				this.Installers[i].Context = this.Context;
			}
			for (int j = 0; j < this.Installers.Count; j++)
			{
				Installer installer = this.Installers[j];
				IDictionary dictionary = new Hashtable();
				try
				{
					num = j;
					installer.Install(dictionary);
				}
				finally
				{
					list.Add(dictionary);
				}
			}
		}
		finally
		{
			stateSaver.Add("_reserved_lastInstallerAttempted", num);
			stateSaver.Add("_reserved_nestedSavedStates", list.ToArray(typeof(IDictionary)));
		}
		try
		{
			this.OnAfterInstall(stateSaver);
		}
		catch (Exception exception2)
		{
			this.WriteEventHandlerError(Res.GetString("InstallSeverityError"), "OnAfterInstall", exception2);
			throw new InvalidOperationException(Res.GetString("InstallEventException", new object[] { "OnAfterInstall", base.GetType().FullName }), exception2);
		}
	}
