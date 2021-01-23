    Private Sub AddImgRVToolBar()
        Dim ts As ToolStrip = Me.FindToolStrip(Of ToolStrip)(Me.ReportViewer1)
        
                If ts IsNot Nothing Then
                    Dim exportButton As ToolStripDropDownButton = TryCast(ts.Items("export"), ToolStripDropDownButton)
        
                    If exportButton IsNot Nothing Then
                        AddHandler exportButton.DropDownOpened, AddressOf OnExportOpened
                    End If
                End If
    End Sub
        
        Private Sub OnExportOpened(sender As Object, e As EventArgs)
                If TypeOf sender Is ToolStripDropDownButton Then
                    Dim button As ToolStripDropDownButton = DirectCast(sender, ToolStripDropDownButton)
        
                    For Each item As ToolStripItem In button.DropDownItems
                        Dim extension As RenderingExtension = DirectCast(item.Tag, RenderingExtension)
        
                        If extension IsNot Nothing Then
                            Select Case extension.Name
                                Case "Excel"
                                    item.Image = My.Resources.page_white_excel_16x16
                                Case "PDF"
                                    item.Image = My.Resources.page_white_acrobat_16x16
                                Case "WORD"
                                    item.Image = My.Resources.page_white_word_16x16
                                    item.Text = "Word"
                            End Select
                        End If
                    Next
                End If
            End Sub
        
            Private Function FindToolStrip(Of T As System.Windows.Forms.Control)(ByVal control As Control) As T
                If control Is Nothing Then
                    Return Nothing
                ElseIf TypeOf control Is T Then
                    Return DirectCast(control, T)
                Else
                    Dim result As T = Nothing
        
                    For Each embedded As Control In control.Controls
                        If result Is Nothing Then
                            result = FindToolStrip(Of T)(embedded)
                        End If
                    Next
        
                    Return result
                End If
            End Function
