    private Outlook.MAPIFolder _CalendarFolder = null;
    private Outlook.Items _CalendarItems = null;
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Outlook.MAPIFolder calendarFolder =
            this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
                
        // get the Termine24-Folder (if not found, create it)
        try
        {
            _CalendarFolder = calendarFolder.Folders[Constants.FOLDERNAME];
        }
        catch
        {
            _CalendarFolder = calendarFolder.Folders.Add(Constants.FOLDERNAME);
        }
        _CalendarItems = _CalendarFolder.Items;
        attachEvents();
              
    }
    public void attachEvents()
    {
        _CalendarItems.ItemAdd += Item_Add;
        _CalendarItems.ItemChange += Item_Change;
        _CalendarItems.ItemRemove += Item_Remove;
    }
    public void Item_Add(Object item)
    {
        Outlook.AppointmentItem aitem = item as Outlook.AppointmentItem;
        if (aitem != null)
        {
            MessageBox.Show("add: " + aitem.Subject);
        }
        else
        {
            MessageBox.Show("add, but no appointment");
        }
    }
    public void Item_Change(Object item)
    {
        Outlook.AppointmentItem aitem = item as Outlook.AppointmentItem;
        if (aitem != null)
        {
            MessageBox.Show("changed: " + aitem.Subject);
        }
        else
        {
            MessageBox.Show("change, but no appointment");
        }
    }
    public void Item_Remove()
    {
        MessageBox.Show("Item_remove");
    }
