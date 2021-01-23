        Dim UsePanelScroll As Boolean = False
        Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'some code
            If UsePanelScroll = True Then
                Panel1.Focus()
            End If
        End Sub
        Private Sub ComboBox_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs)
            Select Case e.KeyCode
                Case Keys.Tab, Keys.Up, Keys.Down
                    UsePanelScroll = False
                Case Else
                    UsePanelScroll = True
            End Select
        End Sub
        
        Private Sub ComboBox_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
            If e.Button = Windows.Forms.MouseButtons.Left Then
                UsePanelScroll = True
            End If
        End Sub
