    if (Session["CurrCatId"] != null)
    {
        CurrCatId = (int)(Session["CurrCatId"]);
        // if the dictionary isn't even in Session yet then add it
        if (Session["itemColl"] == null)
        {
            Session["itemColl"] = new Dictionary<int, int>();
        }
        // now we can safely pull it out every time
        itemColl = (Dictionary<int, int>)Session["itemColl"];
        // if the CurrCatId doesn't have a key yet, let's add it
        // but with an initial value of zero
        if (!itemCol1.ContainsKey(CurrCatId))
        {
            itemColl.Add(CurrCatId, 0);
        }
        // now we can safely increment it
        itemCol1[CurrCatId]++;
        // now store that Dictionary back in session
        // NOTE: this line is probably not necessary but
        // it's not going to hurt anything
        Session["itemColl"] = itemColl;                        
    }
