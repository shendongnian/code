    /// <summary>
    /// parses a table and returns a list containing all the data with columns separated by tabs
    /// e.g.: records = getTable(doc, 0);
    /// </summary>
    /// <param name="doc">HtmlDocument to work with</param>
    /// <param name="number">table index (base 0)</param>
    /// <returns>list containing the table data</returns>
    public List<string> getTableData(HtmlDocument doc, int number)
    {
      HtmlElementCollection tables = doc.GetElementsByTagName("table");
      int idx=0;
      List<string> data = new List<string>();
      
      foreach (HtmlElement tbl in tables)
      {
        if (idx++ == number)
        {
          data = getTableData(tbl);
          break;
        }
      }
      return data;
    }
    /// <summary>
    /// parses a table and returns a list containing all the data with columns separated by tabs
    /// e.g.: records = getTable(getElement(doc, "table", "id", "table1"));
    /// </summary>
    /// <param name="tbl">HtmlElement table to work with</param>
    /// <returns>list containing the table data</returns>
    public List<string> getTableData(HtmlElement tbl)
    {
      int nrec = 0;
      List<string> data = new List<string>();
      string rowBuff;
      HtmlElementCollection rows = tbl.GetElementsByTagName("tr");
      HtmlElementCollection cols;
      foreach (HtmlElement tr in rows)
      {
        cols = tr.GetElementsByTagName("td");
        nrec++;
        rowBuff = nrec.ToString();
        foreach (HtmlElement td in cols)
        {
          rowBuff += "\t" + WebUtility.HtmlDecode(td.InnerText);
        }
        data.Add(rowBuff);
      }
      return data;
    }
