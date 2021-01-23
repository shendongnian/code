    protected override void OnPreRender(EventArgs e)
    {
        // why do you need a list as field variable at all? I assume a local variable is fine
        List<int> CurrentList = new List<int>();
        foreach(var currentItemId in ShareWith.Items)
        {
            System.Web.UI.WebControls.DataKey currentDataKey = this.lvShareWithPanel.DataKeys[currentItemId.DataItemIndex];
            int FriendId = Convert.ToInt32(currentDataKey["SharedUserId"]);
            CurrentList.Add(FriendId);
        }
        // do something with the list
    }
