    private string AddUsers(HttpPostedFileBase file)
        {
            string tempFileName = string.Format("{0}_{1}", Guid.NewGuid(), Path.GetFileName(file.FileName));
            string filePath = Path.Combine(Server.MapPath("~/AD_App_Data/temp"), tempFileName);
            file.SaveAs(filePath);
            FileInfo tempFileInfo = new FileInfo(filePath);
            List<string[]> tempFileData = new List<string[]>();
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(tempFileInfo.FullName, true))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splitter = line.Split(';');
                    lines.Add(line);
                    tempFileData.Add(splitter);
                }
            }
            tempFileInfo.Delete();
            if ((tempFileData[0][0].ToLower() != "samaccountname") ||
                (tempFileData[0][1].ToLower() != "displayname"))
            {
                return "Error! sAMAccountName or displayName fields not found!";
            }
            List<string> users = new List<string>();
            try
            {
                string LDAPContextPath = string.Format(
                    "LDAP://{0}/{1}",
                    ActiveDirectoryManage.GetServerName(),
                    ActiveDirectoryManage.GetLDAPUserPath());
                List<string> newUsersPassword = new List<string>();
                foreach (string[] data in tempFileData.Skip(1))
                {
                    if (impersonateValidUser("Administrator", ActiveDirectoryManage.GetDomainName(), "abcd,1234"))
                    {
                        using (DirectoryEntry context = new DirectoryEntry(LDAPContextPath, "Administrator", "abcd,1234"))
                        {
                            users.Add(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            using (DirectoryEntry userEntry = context.Children.Add(string.Format("CN={0}", data[1]), "user"))
                            {
                                userEntry.Properties["sAMAccountName"].Value = data[0];
                                userEntry.CommitChanges();
                                for (int i = 1; i < data.Length; i++)
                                {
                                    int number;
                                    if (int.TryParse(data[i], out number))
                                    {
                                        userEntry.Properties[tempFileData[0][i]].Value = number;
                                    }
                                    else
                                    {
                                        userEntry.Properties[tempFileData[0][i]].Value = data[i];
                                    }
                                    userEntry.CommitChanges();
                                }
                                string newPassword = Membership.GeneratePassword(12, 0);
                                userEntry.Invoke("SetPassword", newPassword);
                                userEntry.CommitChanges();
                                newUsersPassword.Add(newPassword);
                                userEntry.Properties["userAccountControl"].Value = 512;
                                userEntry.CommitChanges();
                            }
                        }
                        undoImpersonation();
                    }
                    else
                    {
                        return "Error! Impersonation Failed";
                    }
                }
                string timestamp = string.Format(
                    "{0}{1}{2}-{3}{4}{5}",
                    DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second,
                    DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
                string doneFileName = string.Format("{0}_{1}.csv", file.FileName, timestamp);
                string donePath = Path.Combine(Server.MapPath("~/AD_App_Data/done"), doneFileName);
                using (StreamWriter writer = new StreamWriter(donePath))
                {
                    writer.WriteLine(AppendPassword(lines[0], "password"));
                    for (int i = 1; i < lines.Count; i++)
                    {
                        writer.WriteLine(AppendPassword(lines[i], newUsersPassword[i - 1]));
                    }
                }
                return doneFileName;
            }
            catch (Exception ex)
            {
                string error = "Error! Exception! " + ex.Message + "\n\n";
                foreach (string s in users)
                {
                    error = error + s + "\n\n";
                }
                return error;
            }
        }
