    using (ICMSEntities db = new ICMSEntities())  
    { 
        foreach (ListItem item in cblSectors.Items)
        {
            int SectorID = item.Convert.ToInt32(item.Value);
            if (item.Selected && !productObj.Sectors.Any(s => s.SectorID == SectorID))
            {
                Sector sectorObj = db.Sectors.Single(x => x.sector_id == SectorID);  
                productObj.Sectors.Add(sectorObj);  
            } 
            else if (!item.Selected && productObj.Sectors.Any(s => s.SectorID == SectorID))
            {
                var sector = productObj.Sectors.Single(s => s.SectorID == SectorID);
                productObj.Sectors.Remove(sector);
            }
        }
        db.SaveChanges();  
        Response.Redirect("~/Products.aspx", true);  
    }
