    rep.SetDataSource(ds.Tables[0]);
            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    rep.OpenSubreport("Subrep1").SetDataSource(ds.Tables[1]);
                }
    
            }
      
    
    rep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "ABCDReport");
