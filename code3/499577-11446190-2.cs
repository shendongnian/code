    private void btnDel_Click(object sender, EventArgs e)
    {
        using (testEntities Setupctx = new testEntities())
        {
            var Lo = Convert.ToString(cbLocationData.SelectedValue);
            var DeleteLocation = (from delLocation in Setupctx.locations
                                  where delLocation.Location1 == Lo
                                  select delLocation).SingleOrDefault();
            if (DeleteLocation != null)
            {
                Setupctx.DeleteObject(DeleteLocation);
                Setupctx.SaveChanges();
                this.Delete_Location_Load(null, EventArgs.Empty);
                MessageBox.Show("Selected Shift Timing Has Been Deleted.");
            }
        }
    }
