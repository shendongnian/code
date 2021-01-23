    private void frmViewBookings_Load(object sender, EventArgs e)
    {
        // TODO: This line of code loads data into the 'usersDataSet1.Booking' table. You can move, or remove it, as needed.
        UpdateData();
    
    }
    
    public void UpdateData()
    {
        this.bookingTableAdapter.Fill(this.usersDataSet1.Booking);
    }
