    <DllImport("user32.dll")> _
    Public Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As AnimateStyles) As Boolean
    End Function
    Public Enum AnimateStyles As Integer
        Slide = 262144
        Activate = 131072
        Blend = 524288
        Hide = 65536
        Center = 16
        HOR_Positive = 1
        HOR_Negative = 2
        VER_Positive = 4
        VER_Negative = 8
    End Enum
    Private m_CoverUp As Form
    Private Sub StartFade()
        m_CoverUp = New Form()
        With m_CoverUp
            .Location = Me.PointToScreen(Me.pnlMain.Location)
    	    .Size = Me.pnlMain.Size
            .FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            .BackColor = Drawing.SystemColors.Control
            .Visible = False
            .ShowInTaskbar = False
            .StartPosition = System.Windows.Forms.FormStartPosition.Manual
        End With
        AnimateWindow(m_CoverUp.Handle, 100, AnimateStyles.Blend) 'Blocks
        Invoke(New MethodInvoker(AddressOf ShowPage))
    End Sub
    
	Private Sub EndFade()
		AnimateWindow(m_CoverUp.Handle, 100, AnimateStyles.Blend Or AnimateStyles.Hide)
		m_CoverUp.Close()
		m_CoverUp = Nothing
	End Sub
    
