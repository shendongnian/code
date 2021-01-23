    Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
    Dim myReport As New ReportDocument()
    myReport.Load(Server.MapPath("ReportName")) -- name of the crystal report
     
    Dim myTables As Tables = myReport.Database.Tables
     
    For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
      Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
      myConnectionInfo.ServerName = "" -- <SQL servername>
      myConnectionInfo.DatabaseName = "" -- leave database name blank
      myConnectionInfo.UserID = "" -- username
      myConnectionInfo.Password = "" -- password
      myTableLogonInfo.ConnectionInfo = myConnectionInfo
      myTable.ApplyLogOnInfo(myTableLogonInfo)
    Next
     
    CrystalReportViewer1.ReportSource = myReport
