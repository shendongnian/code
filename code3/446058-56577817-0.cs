        Dim Data_Table As New DataTable("DataTable1") *'Create New Data Table in DataSet having same columns as are there in your Datatable*
        Dim Query As String
        Query = "SELECT Caption,Mobile,Age,City FROM Bond.Book"
        Dim Command As New SqlCommand(Query, Connection)
        Dim Table_Adapter As New SqlDataAdapter(Command)
        Table_Adapter.Fill(Data_Table)
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Book.rdlc")
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("Book_DataSet", Data_Table))
        ReportViewer1.LocalReport.Refresh()
    End Sub
