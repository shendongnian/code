    public ActionResult GetRegionList(int ID)
    {
        int countryid = ID;           
        AddressModel objmodel = new AddressModel();
        List<Region> objRegionList = new List<Region>();
        objRegionList.Add(new Region { ID = "0", Name = " " });
        if (countryid != 0)
        {
            countryid = Convert.ToInt32(ID);
            SqlCommand cmd = new SqlCommand("USP_ProcedureName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", countryid);
            cmd.Parameters.AddWithValue("@Mode", "Region");
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["RegionId"].ToString() != "")
                {
                    objRegionList.Add(new Region { ID = dr["RegionId"].ToString(), Name = dr["Name"].ToString() });
                }
            }
            dr.Close();
            con.Close();
        }
        return Json(objRegionList, JsonRequestBehavior.AllowGet);
    }
