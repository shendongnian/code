    Imports Microsoft.Reporting.WebForms
    
    Partial Class Rpt_reports
    Inherits System.Web.UI.Page
      Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ds As New Custamer
            'da.Fill(ds.Tables("custamer")
            Dim path As String = Server.MapPath("customerinfo.rdlc")
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.ReportPath = path
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Rpt_reports", ds.Tables("Custamer")))
            ReportViewer1.LocalReport.Refresh()
        End If
      End Sub
      'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      'End Sub
    End Class
