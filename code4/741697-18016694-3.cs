    public ActionResult GetRegionList(int id)
    {
        var objRegionList = new List<Region>();
        objRegionList.Add(new Region { ID = "0", Name = " " });
        if (countryid != 0)
        {
            int countryid = ID;
            using (var conn = new SqlConnection("YOUR CONNECTION STRING COMES HERE"))
            using (var cmd = conn.CreateCommand())
            {
                con.Open();
                cmd.CommandText = "USP_ProcedureName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", countryid);
                cmd.Parameters.AddWithValue("@Mode", "Region");
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["RegionId"].ToString() != "")
                        {
                            objRegionList.Add(new Region 
                            { 
                                ID = dr["RegionId"].ToString(), 
                                Name = dr["Name"].ToString() 
                            });
                        }
                    }
                }
            }
        }
        return Json(objRegionList, JsonRequestBehavior.AllowGet);
    }
