    SqlParameter[] prms = new SqlParameter[]
    {
       new SqlParameter("@offer_name", SqlDbType.NVarChar),
       new SqlParameter("@offer_price", SqlDbType.Money),
       new SqlParameter("@start_date", SqlDbType.SmallDateTime),
       new SqlParameter("@end_date", SqlDbType.SmallDateTime)
    };
    prms[0].Value = this.offer_name;
    prms[1].Value = this.offer_price;
    prms[2].Value = this.start_date;
    prms[3].Value = this.end_date;
    int result = DbAcess.Insert_Query(Query_string, prms);
    
