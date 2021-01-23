    private static object DbSafe(object value) {
      if ((value != null) || (value != DBNull.Value)) {
        string strVal = value.ToString();
        if (!String.IsNullOrEmpty(strVal)) {
          return strVal.Trim();
        }
      }
      return DBNull.Value;
    }
