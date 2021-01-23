    Private Sub dgvEcheancier_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEcheancier.CurrentCellDirtyStateChanged
            nbreClick += 1
                With dgvEcheancier
                    Select Case .CurrentCell.ColumnIndex
                    Case 9
                        Dim col As DataGridViewComboBoxColumn = .Columns(9)
                        If TypeOf (col) Is DataGridViewComboBoxColumn Then
                            dgvEcheancier.CommitEdit(DataGridViewDataErrorContexts.Commit)
                            If nbreClick = 2 Then
                                MessageBox.Show("y" & "val=" & .CurrentCell.Value)
                                nbreClick = 0
                            End If
                        End If
    
                End Select
                End With
