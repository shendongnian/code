    Public Shared Sub Export(ByVal fileName As String, ByVal gv As GridView, Optional ByVal IncludeFooter As Boolean = True)
    
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
            HttpContext.Current.Response.Charset = "UTF-8"
            Dim sw As StringWriter = New StringWriter
            Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
            '  Create a form to contain the grid
            Dim table As Table = New Table
            '  add the header row to the table
            If (Not (gv.HeaderRow) Is Nothing) Then
                myGridview.PrepareControlForExport(gv.HeaderRow)
                table.Rows.Add(gv.HeaderRow)
            End If
            '  add each of the data rows to the table
            For Each row As GridViewRow In gv.Rows
                myGridview.PrepareControlForExport(row)
                table.Rows.Add(row)
            Next
            '  add the footer row to the table
            If IncludeFooter Then
                If (Not (gv.FooterRow) Is Nothing) Then
                    myGridview.PrepareControlForExport(gv.FooterRow)
                    table.Rows.Add(gv.FooterRow)
                End If
            End If
            '  render the table into the htmlwriter
            table.RenderControl(htw)
            '  render the htmlwriter into the response
            HttpContext.Current.Response.Write(Replace(sw.ToString, "'", "''"))
    
            HttpContext.Current.Response.End()
        End Sub
    
        ' Replace any of the contained controls with literals
        Private Shared Sub PrepareControlForExport(ByVal control As Control)
            Dim i As Integer = 0
            Do While (i < control.Controls.Count)
                Dim current As Control = control.Controls(i)
                If (TypeOf current Is LinkButton) Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(CType(current, LinkButton).Text))
                ElseIf (TypeOf current Is ImageButton) Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(CType(current, ImageButton).AlternateText))
                ElseIf (TypeOf current Is HyperLink) Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(CType(current, HyperLink).Text))
                ElseIf (TypeOf current Is DropDownList) Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(CType(current, DropDownList).SelectedItem.Text))
                ElseIf (TypeOf current Is CheckBox) Then
                    control.Controls.Remove(current)
                    control.Controls.AddAt(i, New LiteralControl(CType(current, CheckBox).Checked))
                    'TODO: Warning!!!, inline IF is not supported ?
                End If
                If current.HasControls Then
                    myGridview.PrepareControlForExport(current)
                End If
                i = (i + 1)
            Loop
        End Sub
