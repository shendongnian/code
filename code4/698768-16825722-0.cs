    Sub InsertPicture(ByVal oImg As Image)
        Dim oFoto As Image
        Dim x, y As Integer
        oFoto = oImg
        picImg.Visible = False
        picImg.Width = picFrame.Width - 2
        picImg.Height = picFrame.Height - 2
        picImg.Location = New Point(1, 1)
        SetPicture(picPreview, oFoto)
        x = (picImg.Width - picFrame.Width) / 2
        y = (picImg.Height - picFrame.Height) / 2
        picImg.Location = New Point(x, y)
        picImg.Visible = True
    End Sub
