    protected void ResetAvgRT_Click(object sender, EventArgs e)
    {
        using (RamRideOpsEntities myEntities = new RamRideOpsEntities())
        {
            var avgTime = (from a in myEntities.AdminOptions
                               select a).First();
            if (a.avgTime != null)
            {
                a.avgTime = null;
                myEntities.Entry(a).State = EntityState.Modified;
                myEntities.SaveChanges();
            }
        }
    }
