    Public Shared Function ImageList_FromHIMAGELIST(cxcy As Integer, uFlags As UInteger, initSize As Integer, growSize As Integer, _
                                             hicons() As IntPtr) As ImageList
        Dim himl = ImageList_Create(cxcy, cxcy, uFlags, initSize, growSize)
        If Not IsNothing(hicons) AndAlso hicons.Length > 0 Then
            For Each HIcon As IntPtr In hicons
                ImageList_ReplaceIcon(himl, -1, HIcon)
            Next
        End If
        Dim NativeILType As Type = _
            GetType(Button).Assembly.GetType("System.Windows.Forms.ImageList+NativeImageList", False, True)
        If IsNothing(NativeILType) Then
            Return Nothing
        Else
            Dim natObj As Object = _
                Activator.CreateInstance( _
                    NativeILType, BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, {himl}, Nothing)
            If Not IsNothing(natObj) Then
                Dim iml As New ImageList With {.ImageSize = New Size(cxcy, cxcy)}
                iml.GetType.InvokeMember("nativeImageList", _
                                         BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetField, _
                                          Nothing, iml, {natObj})
                Return iml
            End If
        End If
        Return Nothing
    End Function
