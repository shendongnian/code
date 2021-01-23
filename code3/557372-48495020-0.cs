        Public Sub SpellCheckButton(ByVal Control As Office.IRibbonControl)
            Try
                Dim result As String = "Spelled incorrectly."
                If Me.Application.CheckSpelling(Me.Range.Text) = True Then
                    result = "Spelled correctly."
                End If
                MessageBox.Show(result)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End Sub
