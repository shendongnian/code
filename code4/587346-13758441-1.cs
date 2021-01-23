    try
    {
            SvnClient clientN = new SvnClient();
            clientN.Authentication.Clear();//clear a previous authentication
            clientN.Authentication.DefaultCredentials = new System.Net.NetworkCredential("pkumar", "pkumar");
            Collection<SvnListEventArgs> list;
            if (clientN.GetList("svn://india01/Repo/branches/xyz", out list))//this will chk the branch exist or not. if not it will move to catch block
            {
                lblMsg.text = "branch exist";
                 //do what you want here
            }
    }
    catch(SvnFileSystemException sfse)
    {
        lblMsg.text = "branch does not exist";
    }
