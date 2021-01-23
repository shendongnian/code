    public string propLat = "";
    public string propLan = "";
    public void getLatLan(int PropertyId)
    {
        DataSet dstPropMap = Tbl_PropertyMaster.GetPropertyDetailsbyId(PropertyId);
        if (dstPropMap.Tables[0].Rows.Count > 0)
        {
            propLat = dstPropMap.Tables[0].Rows[0]["Latitude"].ToString().Trim();
            propLan = dstPropMap.Tables[0].Rows[0]["Longitude"].ToString().Trim();
        }
    }
