      void InsertBuyBackExceldata(string filePath)
      {
           if (buyBackServiceProxyController == null)
             buyBackServiceProxyController = new ProxyController();
           buyBackServiceServiceProxy = buyBackServiceProxyController.GetProxy();
           ListBuyBackrequest = new List();
           String[] a= GetExcelSheetNames(filePath); // This method for get sheet names
           var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", filePath);
           //string a=filePath.
            String sheetName = a[0];
           var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", connectionString);
           var ds = new DataSet();
           adapter.Fill(ds, sheetName );
           DataTable data = ds.Tables[sheetName ];
           BindGrid(data);
      }
