    Private Sub cmdBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBack.Click
            Try
                Dim PrevForm As Form = Nothing
                For Each ChildForm As Form In Me.MdiChildren
                    If ChildForm.Equals(Me.ActiveMdiChild) Then
                        If Not IsNothing(PrevForm) Then
                            Me.ActivateMdiChild(PrevForm)
                            PrevForm.Focus()
                            Exit For
                        End If
                    End If
                    PrevForm = ChildForm
                Next
                PrevForm = Nothing
            Catch ex As Exception
     
            End Try
        End Sub
