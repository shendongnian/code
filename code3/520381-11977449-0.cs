    private static void ThrowSqlException()
    {
        using (var cxn = new SqlConnection("Connection Timeout=1"))
        {
            cxn.Open();
        }
    }
    // ...
    mockAccountDAL.Setup(m => m.CreateAccount(It.IsAny<string>),
                         "Display Name 2", It.IsAny<string>()))
                  .Returns(() => ThrowSqlException());
