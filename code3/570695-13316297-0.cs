    public static SqlParameter PositiveOrNullSqlParameter( this float value , string name )
    {
        return PositiveOrNullSqlParameter( (double) value , name ) ;
    }
    public static SqlParameter PositiveOrNullSqlParameter( this double value , string name )
    {
        SqlParameter p = new SqlParameter( name , System.Data.SqlDbType.Float ) ;
        p.Value = ( value > 0 ? (object) value : (object) DBNull.Value ) ;
        return p ;
    }
