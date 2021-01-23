    var values = new[]{
                        item.RecordId,
                        item.Tokens,
                        string.Format("{0}:{1}", item.OwnerID.SystemName, item.OwnerID.Port),
                        item.ChildID.UserName
                        item.TypeOfLicense
                        item.ExpiryTime.DateTime};
    var showIndexes = from item in lItems
                      where WildcardString.IsMatch(values,filter)
                               select item.RecordId.ToString();
