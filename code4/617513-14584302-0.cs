    public bool MyIsMatch(MyType item, String filter)
    {
        return
        WildcardString.IsMatch(item.RecordId.ToString(), filter) ||
        WildcardString.IsMatch(item.Tokens.ToString(), filter) ||
        WildcardString.IsMatch(string.Format("{0}:{1}", item.OwnerID.SystemName, item.OwnerID.Port.ToString()), filter) ||
        WildcardString.IsMatch(item.ChildID.UserName, filter) ||
        WildcardString.IsMatch(item.TypeOfLicense.ToString(), filter) ||
        WildcardString.IsMatch(item.ExpiryTime.DateTime.ToLocalTime().ToString(), filter);
    }
