    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Sub CreateCaret(ByVal hWnd As IntPtr, ByVal hBitmap As IntPtr, ByVal nWidth As Integer, ByVal nHeight As Integer)
    End Sub
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Sub ShowCaret(ByVal hWnd As IntPtr)
    End Sub
    Private mInsertKeyState As Boolean = True
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Insert Then
            mInsertKeyState = Not mInsertKeyState
        End If
        Me.DrawCaret()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal mevent As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(mevent)
        Me.DrawCaret()
    End Sub
    Public Sub DrawCaret()
        Dim nHeight As Integer = 0
        Dim nWidth As Integer = 0
        If Me.SelectionFont IsNot Nothing Then
            nHeight = CInt(Me.SelectionFont.Height * Me.ZoomFactor)
        Else
            nHeight = CInt(Me.Font.Height * Me.ZoomFactor)
        End If
        If Not mInsertKeyState AndAlso Me.SelectionStart < Me.TextLength Then
            Dim p1 As Point = MyBase.GetPositionFromCharIndex(Me.SelectionStart)
            Dim p2 As Point = MyBase.GetPositionFromCharIndex(Me.SelectionStart + 1)
            nWidth = p2.X - p1.X
        End If
        CreateCaret(Me.Handle, IntPtr.Zero, nWidth, nHeight)
        ShowCaret(Me.Handle)
    End Sub
