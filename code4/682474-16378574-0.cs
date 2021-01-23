     private void EditConString(string connName, string user, string pwd, string server,string database)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings[connName].ConnectionString = "Server=" + server + ";User Id=" + user + ";password=" + pwd + ";database=" + database + ";ConnectionTimeout = 60;Allow Zero Datetime=True";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
