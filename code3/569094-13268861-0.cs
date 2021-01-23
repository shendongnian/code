    using(TransactionScope ts = TransactionUtils.CreateTransactionScope()){
      using(SqlConnection conn = new SqlConnection(connString)){
        conn.Open();
        using(SqlCommand cmd = new SqlCommand("DELETE FROM tableName WHERE somethingorother", conn)){
        cmd....
    
        }
        using(SqlCommand cmd ....) ...
        thingy.Save();//uses another command/connection possibly
       }
    
    //all above Sql Calls will be done at this point. all or nothing
      ts.Complete();
    }
