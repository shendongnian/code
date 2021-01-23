            ConnectionOptions oConn = new ConnectionOptions();
            oConn.Username = "user1";
            oConn.Password = "user1password";
            ManagementScope scope = new ManagementScope(@"//" + "PC1" + @"/root/default", oConn);
            scope.Connect();
            ManagementClass mc = new ManagementClass("stdRegProv");
            mc.Scope = scope;
            ManagementBaseObject mbo;
            mbo = mc.GetMethodParameters("EnumValues");
            mbo.SetPropertyValue("sSubKeyName", @"SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources");
            string[] subkeys = (string[])mc.InvokeMethod("EnumValues", mbo, null).Properties["sNames"].Value;
            foreach (string strKey in subkeys)
            {
                MessageBox.Show(strKey);
            } 
