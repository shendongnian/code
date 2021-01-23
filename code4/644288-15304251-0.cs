    Public Class MyListBox
      Inherits ListBox
    
      Private WM_KILLFOCUS As Integer = &H8
    
      Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg <> WM_KILLFOCUS Then
          MyBase.WndProc(m)
        End If
      End Sub
    
    End Class
