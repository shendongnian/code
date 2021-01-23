        'VB.NET Code
         
    
    Private Sub DG_Data_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles DG_Data.RowDataBound
                Try
        
                    'fusion , rowspan , colspan , 
                    If e.Row.RowType = DataControlRowType.DataRow Then
                        If e.Row.RowIndex Mod 4 = 0 Then
                            e.Row.Cells(0).Attributes.Add("rowspan", "4")
                        Else
                            e.Row.Cells(0).Visible = False
                        End If
                    End If
        
        
        
                Catch ex As Exception
                    jq.msgErrorLog(ex)
                End Try
            End Sub
