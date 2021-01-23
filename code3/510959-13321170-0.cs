    internal static decimal Read(IDbCommand cmd)
    {
        cmd.CommandText = @"SELECT column FROM tablename LIMIT 1";
        using (var r = cmd.ExecuteReader())
        {
            while(r.Read())
            {
                return Convert.ToDecimal(r[0]);
                //instead of return r.GetDecimal(0);
                //or even better return r[0].ToFormattedDecimal();
            }
        }
    }
    public static decimal ToFormattedDecimal(this object d)
    {
        if (d is DBNull || d == null) //important line - to check DbNull
            return 0; //your value
        try
        {
            return Convert.ToDecimal(d).Normalize();
        }
        catch (Exception ex)
        {
            throw ex;
            // or may be return 0;
        }
    }
    public static decimal Normalize(this decimal d)
    {
        return d / 1.00000000000000000000000000000m;
    }
