    AddHandler wb.Loaded, Sub(sendr As Object, ev As EventArgs)
        wb.IsScriptEnabled = True
        AttachContextMenu()
    End Sub
    AddHandler wb.ScriptNotify, Sub(sender As Object, e As Microsoft.Phone.Controls.NotifyEventArgs)
        Diagnostics.Debug.WriteLine(e.Value.ToString)
    End Sub
