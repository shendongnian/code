    public class ItemEvents : SPItemEventReceiver
    {
        public override void ItemAdded(SPItemEventProperties properties)
        {
            SPListItem item = properties.ListItem;
            DateTime startDate = (DateTime)item["StartDate"];
            DateTime endDate = (DateTime)item["EndDate"];
            TimeSpan difference = endDate - startDate;
            item["DayCount"] = difference.Days;
            item.Update();
        }
    }
