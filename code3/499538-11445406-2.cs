    private void LoadLocation()
    {
           using (testEntities Setupctx = new testEntities())
            {
                var storeLocation = (from vL in Setupctx.locations
                                     select new
                                             {
                                               Location1  =vL.Location1
                                             }
                                     );
    
                    cbLocationData.DataTextField = "Location1";
                    cbLocationData.DataSource = storeLocation;
                    cbLocationData.DataBind();
    
            }
    }
