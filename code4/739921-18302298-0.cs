    private void CreateDefaultRows() 
    {
      DataRow Row = DtTbl.NewRow();
      Row["Name"] = "FIN";
      Row["Engine"] = EngineType.EngineType1;
      DtTbl.Rows.Add(Row);
      DGV.DataSource = DtTbl;
    }
