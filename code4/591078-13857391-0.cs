    public bool PostConditionIsChar(DataRow dr, string query, char charToCheck)
    {
      string firstCol = dr[0].ToString();
      return firstCol.StartsWith(query) ? firstCol.Replace(query, "").Length > 0 && firstCol.Replace(query, "").First() == charToCheck : false;
    }
