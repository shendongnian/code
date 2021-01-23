    public HtmlTable BuildTable<T>(List<T> Data)
    {
      HtmlTable ht = new HtmlTable();
      //Get the columns
      HtmlTableRow htColumnsRow = new HtmlTableRow();
      typeof(T).GetProperties().Select(prop =>
                                            {
                                              HtmlTableCell htCell = new HtmlTableCell();
                                              htCell.InnerText = prop.Name;
                                              return htCell;
                                            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
      ht.Rows.Add(htColumnsRow);
      //Get the remaining rows
      Data.ForEach(delegate(T obj)
      {
        HtmlTableRow htRow = new HtmlTableRow();
        obj.GetType().GetProperties().ToList().ForEach(delegate(PropertyInfo prop)
        {
          HtmlTableCell htCell = new HtmlTableCell();
          htCell.InnerText = prop.GetValue(obj, null).ToString();
          htRow.Cells.Add(htCell);
        });
        ht.Rows.Add(htRow);
      });
      return ht;
    }
