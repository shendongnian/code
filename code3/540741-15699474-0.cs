     protected void Button1_Click(object sender, EventArgs e)
     {
            ReportDocument Summaryrpt = new ReportDocument();
            Summaryrpt.Load(Server.MapPath("BookSummary.rpt"));
            CrystalReportViewer1.ReportSource = Summaryrpt;
            var connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "ComproLottery.db.6456862.hostedresource.com";
            connectionInfo.DatabaseName = "ComproLottery";
            connectionInfo.Password = "Br0@dW@ys68";
            connectionInfo.UserID = "ComproLottery";
            connectionInfo.Type = ConnectionInfoType.SQL;
            for (int i = 0; i < CrystalReportViewer1.LogOnInfo.Count; i++)
            {
                CrystalReportViewer1.LogOnInfo[i].ConnectionInfo = connectionInfo;
            }
      }
