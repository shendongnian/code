    internal static OdbcException CreateException(OdbcErrorCollection errors, ODBC32.RetCode retcode)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (OdbcError odbcError in errors)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append(Res.GetString("Odbc_ExceptionMessage", (object) ODBC32.RetcodeToString(retcode), (object) odbcError.SQLState, (object) odbcError.Message));
      }
      return new OdbcException(((object) stringBuilder).ToString(), errors);
    }
