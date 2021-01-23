    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)
      MyBase.Install(stateSaver)
      Dim myInput As String = Me.Context.Parameters.Item("Message")
      If myInput Is Nothing Then
        myInput = "There was no message specified"
      End If
      MsgBox(myInput)
    End Sub
