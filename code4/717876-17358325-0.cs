    protected void GrdManager()
    {
               MTMSDTO objc = new MTMSDTO();
               
                objc.EmpName = Convert.ToString(Session["EmpName"]);
                DataSet GrdMA = obj.GetManager(objc);
                GridViewTTlist.DataSource = GrdMA.Tables[0];
                GridViewTTlist.DataBind();
               
    }
