    DataSet ds = new DataSet();
    List<SqlParameter> paramz = new List<SqlParameter>();
    paramz.Add(new SqlParameter("@LitHoldDetailsID", litHoldDetailsID));
    DataTable dt = LHClassLibrary.LHDataAccessLayer.ExecuteSelect("usp_GetLitHoldDetails_A", paramz);
    dt.TableName = "BaseData";
    ds.Tables.Add(dt);
