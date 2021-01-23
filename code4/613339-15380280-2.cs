     public void insertCheque()
                {
    
             try {     
      
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@IdBankChequeBook", SqlDbType.Int);
                param[1] = new SqlParameter("@IdBankChequeType", SqlDbType.Int);
                param[2] = new SqlParameter("@IdBankChequeStatus", SqlDbType.Int);
                param[3] = new SqlParameter("@TransType",SqlDbType.Int);
                param[4] = new SqlParameter("@ClientID",SqlDbType.Int);
