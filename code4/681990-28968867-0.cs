    Public MyLibrary as Object
    public sub Workbook_Open()
        EnsureLibraryInitialized
    End Sub
    public Sub EnsureLibraryInitialized()
        Dim addin As COMAddIn
        If MyLibrary is Nothing Then
            For Each addin In Application.COMAddIns
                If InStr(addin.Description, "MyLibrary.COMHelper") Then
                    If addin.object Is Nothing Then
                        'complain it can't connect to library, tell user to reinstall it
                    Else
                        Set MyLibrary = addin.object
                    Exit For
                End If
            Next
        End if
    End Sub
