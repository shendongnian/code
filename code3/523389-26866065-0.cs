                //Get machineSettings session
				var machineSettings = (System.Transactions.Configuration.MachineSettingsSection)ConfigurationManager.GetSection("system.transactions/machineSettings");
				//Allow modifications
				var bReadOnly = (typeof(ConfigurationElement)).GetField("_bReadOnly", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
				bReadOnly.SetValue(machineSettings, false);
				//Change max allowed timeout
				machineSettings.MaxTimeout = TimeSpan.MaxValue;
				using (var t = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1,0,0))) { //1 hour transaction
					//...
				}
