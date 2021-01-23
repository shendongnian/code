      ' Instructions :
      ' Change Manually the "StartPosition" property of "Form2" to "Manual", don't change it with code.
    
        Public Moving_From_Secondary_Form As Boolean = False
    
        ' Move Event Main Form
        Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
            If Not Moving_From_Secondary_Form Then
                If Debugger.IsAttached Then
                    Form2.Location = New Point(Me.Right, Me.Top)
                Else
                    Form2.Location = New Point((Me.Location.X + (Me.Width + (Me.Width - Me.ClientSize.Width))), Me.Location.Y)
                End If
            End If
        End Sub
    
        ' Move Event Secondary Form
        Private Sub Form2_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
            Form1.Moving_From_Secondary_Form = True
            If Debugger.IsAttached Then
                Form1.Location = New Point(Me.Left - Form1.Width, Me.Top)
            Else
                Form1.Location = New Point((Me.Location.X - (Form1.Width + (Form1.Width - Form1.ClientSize.Width))), Me.Location.Y)
            End If
            Form1.Moving_From_Secondary_Form = False
        End Sub
