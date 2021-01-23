    //print method in class
    public String PrintEvents(ObjectCollection items)
    {
        foreach (Event e in m_events)
            items.Add(e.ToString());
    }
    //Foreach that displays the text
    private void cboListEv_SelectedIndexChanged(object sender, EventArgs e)
    {
        String SelectedVenue = cboListEv.Text;
        List<Venue> found = plan.selectVen(SelectedVenue);
        lstEvents.Items.Clear();
        foreach (Venue v in found)
           v.PrintEvents(lstEvents.Items);
    }
