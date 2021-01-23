    'You can try this code----- 
    'Function for null validate for particular type of controls in your form
    Function NullValidate() As Boolean
        NullValidate = True
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text = "" Then
                    MessageBox.Show("Invalid input for " & ctrl.Name)
                    NullValidate = False
                   Exit Function
                Else
                   NullValidate = True
                End If
             End If
        Next
    End Function
    'Function for numeric validate for particular type of controls in your form
     Function NumericValidate() As Boolean
         NumericValidate = True
        For Each ctrl As Control In Me.Controls
             If TypeOf ctrl Is TextBox Then
                 If NumericValidate = IsNumeric(ctrl.text) Then
                       MessageBox.Show("Invalid input for " & ctrl.Name)
                      NumericValidate = False
                      Exit Function
                 Else
                      NumericValidate = True
                 End If
             End If
         Next
       End Function
    Private Sub cmdCalculate_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
         If NullValidate() = True Then
             If NumericValidate() = True Then
                 'your statement is here
             End If
         End If
    End Sub
