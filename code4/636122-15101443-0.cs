    private List<Room> _theRooms = new List<Room>();
    
    private void btnAddRm_Click(object sender, EventArgs e)
    {
        if (!_theRooms.Any(r => string.Compare(r.Name, txtName.Text, StringComparison.CurrentCultureIgnoreCase) == 0))
        {
            addRoom();
        }
    }
