    Public Class _Default
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim ls As New List(Of String)()
            ls.Add("Test")
            ls.Add("Test2")
            gvTest.DataSource = ls
            gvTest.DataBind()
        End Sub
    
        Private Sub gvTest_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTest.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim picker As MKB.TimePicker.TimeSelector = DirectCast(e.Row.FindControl("TimeSelector1"), MKB.TimePicker.TimeSelector)
            End If
        End Sub
        Private Sub Save()
            For Each row As GridViewRow In gvTest.Rows
                Dim picker As MKB.TimePicker.TimeSelector = DirectCast(row.FindControl("TimeSelector1"), MKB.TimePicker.TimeSelector)
            Next
        End Sub
    End Class
