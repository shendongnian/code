    public IEnumerable<object> ReportView(string param1, string param2)
    {
      decimal tmp;
      int storeId = decimal.TryParse(param1, out tmp) ? (int)tmp : 0;
      int titleId = decimal.TryParse(param2, out tmp) ? (int)tmp : 0;
      IEnumerable<object> detailView = new Report().GetData(storeId, titleId);
      return detailView;
    }
