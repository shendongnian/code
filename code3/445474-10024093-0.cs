     Public Sub ExportGridToExcel(ByVal GridView1 As DataGrid, ByVal fileName As String)
            Response.Clear()
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", fileName))
            Response.Charset = ""
            Response.ContentType = "application/vnd.xls"
            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)
            GridView1.RenderControl(htmlWrite)
            Response.Write(stringWrite.ToString())
            Response.Flush()
            Response.[End]()
        End Sub
