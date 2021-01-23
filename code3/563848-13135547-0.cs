        public DirectoryEntry connDirectory(string usr, string pwd)
        {
            string ip = iniMan.IniRead("LDAP", "adres");
            DirectoryEntry oDE;
            oDE = new DirectoryEntry(ip, usr, pwd, AuthenticationTypes.Secure);
            return oDE;
        }
        public bool AD_Login(string kullanici_adi, string sifre)
        {
            try
            {
                DirectoryEntry entLogin = connDirectory(kullanici_adi, sifre);
                object loginObj = entLogin.NativeObject;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        void TestMetod(){
         if(AD_Login("ozan","ozan"){
          //ok
         }
        }
