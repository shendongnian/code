    StringBuilder _saveReasonQuery = new StringBuilder();
    public void ApplyRules()
    {
        using(var context = new SpecializedDBEntities())
        {
            _saveReasonQuery.Append("BEGIN ");
            foreach(var item in list)
            {
                //Do something
                SaveReason(item, reasonId);
            }
            _saveReasonQuery.Append("END;");
            context.GetObjectContext().ExecuteStoreCommand(_saveReasonQuery.ToString());
            ctx.SaveChanges();
        }
    }
    //Inside Save Reason
    public void SaveReason(...)
    {
         _saveReasonQuery.Append("INSERT INTO ORDER_IMPLEM_DTL_REASON ");
         _saveReasonQuery.Append("(ORDER_IMPLEM_REASON_ID, SALES_ORDER_IMPLEM_DTL_ID, REASON_ID, REASON_STAT_ID, SALES_ORDER_BRDCST_ID, CREA_BY, CREA_DT)");
         _saveReasonQuery.Append(" VALUES ");
         _saveReasonQuery.Append(String.Format("('0', '{0}', '{1}', '{2}', '{3}', '{4}', TO_DATE('{5}', 'YY-MM-DD HH:mi'));",
                                orderSpot.SALES_ORDER_IMPLEM_DTL_ID, reasonId, Common.Convert_Int64(orderSpot.CUESHT_STAT_ID),
                                orderSpot.SALES_ORDER_DTL_BRDCST_ID, userContext.User.USER_CD, DateTime.Now.ToUniversalTime().ToString("yy-MM-dd hh:mm")));
    }
