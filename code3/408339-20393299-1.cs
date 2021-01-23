    protected void linkDelete_Click(object sender, EventArgs e)
        {
           int locationID =0;
           int.TryParse(((LinkButton)sender).Attributes["locationID"].ToString(),out locationID);
           if (locationID > 0)
           {
               Location loc = Location.GetById(locationID);
               CurrentDataContext.CurrentContext.DeleteObject(loc);
               CurrentDataContext.CurrentContext.SaveChanges();
               bindGv();
           }
        }
