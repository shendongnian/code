    Private Sub ComboBoxClients_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBoxClients.TextChanged
        If (Me.InitiallyLoaded) Then
            LoadData()
        End If
    end sub
