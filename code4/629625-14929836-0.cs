    using System.Text.RegularExpressions;
    
    for (int i=0; i < dtRefNos.Rows.Count; i++)
    {
        intCustId = int.Parse(dtRefNos.Rows[i]["cust_Id"].ToString());
        dsCustmr = custDCCls.FillCustDataSet(intCustId);
        string shrtName = dsCustmr.Tables[0].Rows[0]["cust_Sname"].ToString();
        string str = dtRefNos.Rows[i]["estm_suffix"].toString();
        str = Regex.Replace(str, "ESM", dtRefNos.Rows[i]["shrtName"].toString());
        dtRefNos.Rows[i]["estm_suffix"] = str;
    }
