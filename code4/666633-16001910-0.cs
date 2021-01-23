    public string CheckRole(clsLogin Rolecheck)
        {
            string Role;
            clsDataConduit dataconduit = new clsDataConduit();
            dataconduit.AddParameter("@Username", Rolecheck.username);
            dataconduit.AddParameter("@Password", Rolecheck.password);
            dataconduit.Execute("sproc_tblUsers_FilterByRole");
            Role = dataconduit.QueryResults.Rows[0]["Role"].ToString();
            return Role;
        }
