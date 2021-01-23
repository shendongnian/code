    public CountryTable GetSelectedEventInfo(string SelectedEventID)
    {
        int id = Convert.ToInt32(SelectedEventID);
        return this.context.Event.SingleOrDefault(e => e.EventID == id);
    }
