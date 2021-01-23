        Try
            Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
            Dim rpt As New rptCardPrinting()
            Dim myTables As Tables = rpt.Database.Tables
            For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myConnectionInfo.ServerName = sqlconn
                myConnectionInfo.DatabaseName = ""
                myConnectionInfo.UserID = sqluser
                myConnectionInfo.Password = sqlpass
                myTableLogonInfo.ConnectionInfo = myConnectionInfo
                myTable.ApplyLogOnInfo(myTableLogonInfo)
            Next
            frmReportViewer.CrystalReportViewer1.ReportSource = rpt
            rpt.SetParameterValue("prt", txtCnicPassport.Text)
            rpt.PrintToPrinter(1, False, 0, 0)
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '' \\endreport
