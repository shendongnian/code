    // code behind
    public string createUrl(object itemName, object link)
    {
         return string.Format("showItem.aspx?itemID={0}&link={1}",
             itemName.ToString(),
             HttpUtility.UrlEncode(link.ToString()));
    }
