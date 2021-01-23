        Public Sub DrawCaret()
            If Me.SelectionFont IsNot Nothing Then
                Dim nHeight As Integer = CInt(Me.SelectionFont.Height * Me.ZoomFactor)
                Dim nWidth As Integer = 0
    
                If Not mInsertKeyState AndAlso Me.SelectionStart < Me.TextLength Then
                    Dim p1 As Point = MyBase.GetPositionFromCharIndex(Me.SelectionStart)
                    Dim p2 As Point = MyBase.GetPositionFromCharIndex(Me.SelectionStart + 1)
    
                    nWidth = p2.X - p1.X
                End If
    
                CreateCaret(Me.Handle, IntPtr.Zero, nWidth, nHeight)
                ShowCaret(Me.Handle)
            End If
        End Sub
