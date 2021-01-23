    Private Sub deviceidt_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deviceidt.ParentChanged
            Dim deviceidn As String = System.Net.Dns.GetHostName
            deviceidt.Text = deviceidn
            End If
        End Sub
