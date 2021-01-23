    public async Task<List<AccessDetails>> GetAccessListOfMirror(string mirrorId, string server)
        {
            List<AccessDetails> accessOfMirror = new List<AccessDetails>();
            string loginUserId = SessionManager.Session.Current.LoggedInUserName;
            string userPassword = SessionManager.Session.Current.Password;
          
            using (Service1Client client = new Service1Client())
            {
                client.Open();
                Task<List<AccessDetails>> Detail = client.GetMirrorList1(mirrorId, server, null);
                accessOfMirror = await Detail;
            
            }
           
            return accessOfMirror;
        }
