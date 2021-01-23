    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If ComboBox1.SelectedIndex = -1 Then              
            Return
        Else
            TextBox1.Text = ComboBox1.SelectedValue.ToString   ' if find then show their displaymember in combobox.
        End If
    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Dim value As String = TextBox1.Text
        ComboBox1.SelectedValue = value                                    ' if find then show their displaymember in combobox.
        If ComboBox1.SelectedValue Is Nothing Then                          ' if the id you entered in textbox is not find.
            TextBox1.Text = String.Empty
        End If
