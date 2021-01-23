     Private con As New SqlConnection("YourConnectionString")
        Private com As SqlCommand
    Private Sub DGV_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellClick
            con.Open()
            com = New SqlCommand("SELECT MyPhoto FROM tbGalary WHERE ID=" & DGV.Rows(e.RowIndex).Cells(0).Value, con)
            Dim ms As New MemoryStream(CType(com.ExecuteScalar, Byte()))
            txtPicture.Image = Image.FromStream(ms)
            txtPicture.SizeMode = PictureBoxSizeMode.StretchImage
            com.Dispose()
            con.Close()
    End Sub
