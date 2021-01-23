    Public Class ConfirmDeleteDataGrid
    
    Inherits DataGrid
    
    Public Event DeletedRow(ByVal sender As Object, ByVal e As EventArgs)
    
    Private Const WM_KEYDOWN = &H100
    
    
    
    Public Overrides Function PreProcessMessage(ByRef msg As
    System.Windows.Forms.Message) As Boolean
    
    Dim keyCode As Keys = CType((msg.WParam.ToInt32 And Keys.KeyCode), Keys)
    
    If msg.Msg = WM_KEYDOWN And keyCode = Keys.Delete Then
    
    If MessageBox.Show("Delete This Row?", "Confirm Delete", _
    
    MessageBoxButtons.YesNo) = DialogResult.No Then
    
    Return True
    
    Else
    
    RaiseEvent DeletedRow(Me, New EventArgs)
    
    End If
    
    End If
    
    Return MyBase.PreProcessMessage(msg)
    
    End Function
    
    Protected Overrides Function ProcessDialogKey(ByVal keyData As
    System.Windows.Forms.Keys) As Boolean
    
    Dim pt As Point
    
    Dim hti As DataGrid.HitTestInfo
    
    pt = Me.PointToClient(Cursor.Position)
    
    hti = Me.HitTest(pt)
    
    If keyData = Keys.Delete Then
    
    If hti.Type = Me.HitTestType.RowHeader Then
    
    If MessageBox.Show("Delete this row?", "Confirm Delete", _
    
    MessageBoxButtons.YesNo) = DialogResult.No Then
    
    Return True
    
    Else
    
    RaiseEvent DeletedRow(Me, New EventArgs)
    
    End If
    
    End If
    
    End If
    
    Return MyBase.ProcessDialogKey(keyData)
    
    End Function
    
    
    
    Protected Overrides Sub OnMouseDown(ByVal e As
    System.Windows.Forms.MouseEventArgs)
    
    Dim hti As DataGrid.HitTestInfo = Me.HitTest(New Point(e.X, e.Y))
    
    If hti.Type = DataGrid.HitTestType.ColumnResize Or hti.Type =
    DataGrid.HitTestType.RowResize Then
    
    Return 'no baseclass call
    
    End If
    
    MyBase.OnMouseDown(e)
    
    End Sub
    
    Public Sub New()
    
    Trace.WriteLine(Me.VertScrollBar.Visible.ToString)
    
    End Sub
    
    Protected Overrides Sub OnMouseMove(ByVal e As
    System.Windows.Forms.MouseEventArgs)
    
    Dim hti As DataGrid.HitTestInfo = Me.HitTest(New Point(e.X, e.Y))
    
    If hti.Type = DataGrid.HitTestType.ColumnResize Or hti.Type =
    DataGrid.HitTestType.RowResize Then
    
    Return 'no baseclass call
    
    End If
    
    MyBase.OnMouseMove(e)
    
    End Sub
    
    
    End Class
