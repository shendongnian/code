    class MyClass
    {
        List<Webservice.Information> _webServiceInformation = new List<Webservice.Information>()
    
        public void LogonAndStoreInfo()
        {
            Webservice.Information[] pubinfo = myflo.LogOn(username, password, ref ticket, out settings, out users,out terms, out currentUser);
            
            for (int i=0; i < pubInfo.Length; i++)
            {
                StorePubInfo(pubinfo);
            }
    
            Webservice.Information[] myPubInfo = GetPubInfo();
        }
    
        void StorePubInfo(Webservice.Information info)
        {
            _webServiceInformation.Add(info);
        }
    
        Webservice.Information[] GetPubInfo()
        {
            return _webServiceInformation.ToArray();
        }
    }
