    Private Sub SysInfoControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim result As Resources.ResourceSet = My.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, True, True)
        If pics.Count = 0 Then
            For Each elem As DictionaryEntry In result
                If elem.Value.GetType Is GetType(Bitmap) Then
                    pics.Add(elem.Key.ToString(), CType(elem.Value, Bitmap))
                    ImageList1.Images.Add(elem.Key.ToString(), CType(elem.Value, Bitmap))
                End If
            Next
            If pics.ContainsKey(sPic) Then picBoxLoading.Image = pics(sPic)
        End If
    End Sub
