    private void btnDel_Click(object sender, EventArgs e)
    {
        using (testEntities Setupctx = new testEntities())
        {
            var Lo = cbLocationData.SelectedValue;
            var DeleteLocation = (from delLocation in Setupctx.locations
                                  where delLocation.Location1 == Lo
                                  select delLocation).Single();
            Setupctx.DeleteObject(DeleteLocation);
            Setupctx.SaveChanges();
            this.Delete_Location_Load(null, EventArgs.Empty);
            MessageBox.Show("Selected Shift Timing Has Been Deleted.");
        }
    }
