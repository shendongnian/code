    NameValueCollection nvc = new NameValueCollection();
    
    List<BusinessLogic.Donation> donations = new List<BusinessLogic.Donation>();
    donations.Add(new BusinessLogic.Donation(0, "", "", ""));
    donations.Add(new BusinessLogic.Donation(0, "", "", ""));
    donations.Add(new BusinessLogic.Donation(0, "", "", ""));
    
    Enumerable
    	.Range(0, donations.Count())
    	.ForEach(i => nvc.Add("item_number_" + i, donations[i].AccountName));
