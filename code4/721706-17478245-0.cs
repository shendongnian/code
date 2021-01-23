    private void buttonOK_Click(object sender, EventArgs e)
    {
        using(DetailsConn connection = new DetailsConn())
        {
            int driver = -1;
        
            if(int.TryParse(this.DriverTag, out driver)) {
                connection.editPin(driver);
            }
        }
    }
