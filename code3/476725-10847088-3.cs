     //prepare the Ienumerable<MyObject>
     var interventi = GetInterventoSchedeConsuntivi()
     //prepare the report
     IExcelReporting report = ReportingFactory.GetInstance();
     report.SetDatasource(interventi);
     report.AddHeader("Lotto:", lotto);
     report.Columns.AddString((object v) => ((InterventoSchedeConsuntiviView)v).Lotto, "Lotto", 20);
    using (System.IO.Stream s = File.Create(filepath))
                        {
                            byte[] csv = report.ExportToExcel(("titleFile", string.Empty, Servizi.DataOra.Now);
                            s.Write(csv, 0, csv.Length);
                        }
