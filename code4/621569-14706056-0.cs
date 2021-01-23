    public static void ThisAddIn_CheckVersion(Microsoft.Office.Core.COMAddIn ThisAddIn)
		{
			var rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\Addins\\My Outlook Add-in");
			if (rk.GetValue("Username") == null || rk.GetValue("Password") == null)
			{
				new EditSettingsForm(ThisAddIn).Show();
				return;
			}
			var sc = new MyWebService.WebServiceClient();
			sc.ClientCredentials.UserName.UserName = (rk.GetValue("Username") == null ? null : rk.GetValue("Username").ToString());
			sc.ClientCredentials.UserName.Password = (rk.GetValue("Password") == null ? null : Encryptor.Decrypt(rk.GetValue("Password").ToString()));
			if (sc.GetMyOutlookAddinVersionNumber() != "TESTING")
			{
				System.Windows.Forms.MessageBox.Show("The version of My Outlook 2013 Add-in you're using is too old. Please update to the latest version at http://www.foo.bar/");
				ThisAddIn.Connect = false;
			}
			sc = null;
		}
