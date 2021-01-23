    Private Sub DataGridView1_Scroll(sender As Object, e As ScrollEventArgs) Handles DataGridView1.Scroll
        Call closeKeyboard()
    End Sub
    'When a user have to type something in textbox'
    Private Sub Lookup_Tbox_MouseDown(sender As Object, e As MouseEventArgs) Handles Lookup_Tbox.MouseDown 
        Call OpenKeyboard()
    End Sub
    Public Sub OpenKeyboard()
        System.Diagnostics.Process.Start("tabtip.exe")
    End Sub
    Public Sub closeKeyboard()
        Dim proc() As System.Diagnostics.Process = Process.GetProcessesByName("tabtip")
        For i As Integer = 0 To proc.Length - 1
            proc(i).Kill()
        Next i
    End Sub
