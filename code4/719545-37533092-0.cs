        While WebBrowser1.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While
        For i As Integer = 0 To 499
            If WebBrowser1.ReadyState <> System.Windows.Forms.WebBrowserReadyState.Complete Then
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(10)
            Else
                Exit For
            End If
        Next
        System.Windows.Forms.Application.DoEvents()
