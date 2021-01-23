    private void cbLocationData_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (testEntities Setupctx = new testEntities())
        {
            var storeLocation = (from vL in Setupctx.locations
                                 where vL.Location1 == vL.Location1
                                 select vL.Location1);
            foreach (var locationData in storeLocation)
            {
                cbLocationData.Items.Add(locationData.ToString());
            }
        }
    }
