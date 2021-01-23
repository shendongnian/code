            Dim oAssembly As Assembly = Nothing
            Dim oType As Type = Nothing
            Dim oUserControl As System.Windows.Forms.UserControl = Nothing
            
    Dim oArgs As [Object]() = New [Object]() {Me} 'Arguments that you need to pass to the assembly
    
            Try
                ' Set Assembly 
                oAssembly = Assembly.LoadFrom("Your DLL Path")
    
                For Each currentType In oAssembly.GetTypes()
                    If currentType.Name.ToLower.Contains("Name of the class or object in assembly") Then
                        oType = currentType
                        Exit For
                    End If
                Next
    
                oUserControl = DirectCast(oAssembly.CreateInstance(oType.FullName, True, BindingFlags.CreateInstance, Nothing, oArgs, Nothing, Nothing), System.Windows.Forms.UserControl)
    
                Return oUserControl
            Catch ex As Exception
                Return Nothing
            End Try
