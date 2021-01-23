    Dictionary<int, bool> isChecked = new Dictionary<int, bool>();
    
    foreach (LinqToTwitter.User item in twitterCtx.User)
    {
        if (Request.Form["chk" + item.ID.ToString()] != null && Request.Form["chk" + item.ID.ToString()] == "on")
            isChecked.Add(item.ID, true);
        else
            isChecked.Add(item.ID, false);
    }
