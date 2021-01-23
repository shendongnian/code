    public static class DataRowExtensions
    {
        
      #region downcast to DateTime
          
      public static DateTime CastAsDateTime( this DataRow row , int index )
      {
        return toDateTime( row[index] ) ;
      }
      public static DateTime CastAsDateTime( this DataRow row , string columnName )
      {
        return toDateTime( row[columnName] ) ;
      }
      
      public static DateTime? CastAsDateTimeNullable( this DataRow row , int index )
      {
        return toDateTimeNullable( row[index] );
      }
      public static DateTime? CastAsDateTimeNullable( this DataRow row , string columnName )
      {
        return toDateTimeNullable( row[columnName] ) ;
      }
      
      #region conversion helpers
      
      private static DateTime toDateTime( object o )
      {
        DateTime value = (DateTime)o;
        return value;
      }
      
      private static DateTime? toDateTimeNullable( object o )
      {
        bool  hasValue = !( o is DBNull );
        DateTime? value    = ( hasValue ? (DateTime?) o : (DateTime?) null ) ;
        return value;
      }
      
      #endregion
      
      #endregion downcast to DateTime
      // ... other implementations elided .. for brevity
    }
