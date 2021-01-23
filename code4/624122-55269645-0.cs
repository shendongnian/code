        Dim cntrl = New TheClassWithThePrivateImageList
        Dim pi As Reflection.PropertyInfo, iml As System.Windows.Forms.ImageList, propName = "ThePropertyName"
        pi = cntrl.GetType.GetProperty(propName, Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        iml = CType(pi.GetValue(cntrl), System.Windows.Forms.ImageList)
        For Each key In iml.Images.Keys
            Dim image As Drawing.Image = iml.Images.Item(key)
            image.Save($"{propName}_{key}")
        Next
