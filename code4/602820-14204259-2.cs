    DataSet ds = new DataSet();
    List<SqlParameter> paramz = new List<SqlParameter>();
    paramz.Add(new SqlParameter("@LitHoldDetailsID", litHoldDetailsID));
    DataTable dt = LHClassLibrary.LHDataAccessLayer.ExecuteSelect("usp_GetLitHoldDetails_A", paramz);
    dt.TableName = "BaseData";
    if(dt.DataSet != null) dt.DataSet.Tables.Remove(dt);
    ds.Tables.Add(dt);
