    public LawyerInfo[] GetLawyerInfo()
    {
        Sitecore.Data.Database mSiteCoreDB = Sitecore.Configuration.Factory.GetDatabase("master");
        List<LawyerInfo> infos = new List<LawyerInfo>();
        string query = "/sitecore/content/Global Content/People/A";
        Sitecore.Data.Items.Item root = mSiteCoreDB.GetItem(query);
        foreach (Sitecore.Data.Items.Item mBioItem in root.Children)
        {
	        LawyerInfo mInfo = new LawyerInfo();
	        infos.Add(mInfo);
	        mInfo.LawyerID = mBioItem.ID.ToString();
	
	        // your code goes here
                // ...
        }
        return infos.ToArray();
    }
