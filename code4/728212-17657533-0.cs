    internal sealed partial class Settings {
		private MD5 md5 = MD5.Create();
        public global::System.Net.NetworkCredential ApiLogin
        {
            get
            {
                global::System.Net.NetworkCredential tmp = null;
                if (ApiPassword != "")
                {
                    tmp = new System.Net.NetworkCredential();
                    tmp.UserName = ApiUsername;
                    tmp.Password = System.Text.Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(ApiPassword), md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(ApiUsername.ToUpper())), DataProtectionScope.CurrentUser));
                }
                return tmp;
            }
            set
            {
                global::System.Net.NetworkCredential tmp2 = value;
                Webinfinity2RDPUsername = tmp2.UserName;
                ApiPassword = Convert.ToBase64String(ProtectedData.Protect(System.Text.Encoding.UTF8.GetBytes(tmp2.Password), md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(tmp2.UserName.ToUpper())), DataProtectionScope.CurrentUser));
            }
        }
    }
