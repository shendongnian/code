    Dim managedObject As Object
    
    Public Sub RegisterCallback(callback As Object)
        Set managedObject = callback
    End Sub
    
    Public Function GetNumberFromVSTO() As Integer
        GetNumberFromVSTO = managedObject.GetNumber()
    End Function
