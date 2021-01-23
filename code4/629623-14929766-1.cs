    for (int i=0; i < dtRefNos.Rows.Count; i++)
            {
                intCustId = int.Parse(dtRefNos.Rows[i]["cust_Id"].ToString());
                dsCustmr = custDCCls.FillCustDataSet(intCustId);
                string shrtName = dsCustmr.Tables[0].Rows[0]["cust_Sname"].ToString();
                //New Line
                dtRefNos.Rows[i]["estm_suffix"] = drRefNos.Field<string>("estm_suffix")
                                              .Replace("ESM", shrtName);
            }
   
