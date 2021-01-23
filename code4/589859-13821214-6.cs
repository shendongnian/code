    class Logon : Process
    {
        internal Logon(string filename, string username, string passwordtxt, string argument)
        {
            StartInfo.Domain = "Your-Domain";
            StartInfo.FileName = filename;
            StartInfo.UserName = username;
            StartInfo.Password = GetSecurePassword(passwordtxt);
            StartInfo.UseShellExecute = false;
            StartInfo.Arguments = argument;
            StartInfo.LoadUserProfile = true;
        }
    
        public System.Security.SecureString GetSecurePassword(string passwordtxt)
        {
            SecureString SS = new SecureString();
            foreach (char PSW in passwordtxt)
            {
                SS.AppendChar(PSW);
            }
    
            return SS;
        }
    }
